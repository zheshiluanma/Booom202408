using System;
using System.Collections.Generic;
using System.Linq;
using Cfg.Data.Active;
using MoreMountains.TopDownEngine;
using SimpleJSON;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class PlayerExtraAttribute
    {
        //护盾 加成
        public float Shields;
        //血量 加成
        public float HP;
        //投掷物伤害加成
        public float ProjectileDamage;
        //子弹伤害加成
        public float BulletsDamage;
        //暴击率
        public float CritRate;
        //暴击伤害
        public float CritDamage;
    }

    [Serializable]
    public enum PropType
    {
        NovakStabilizers,
        KineticEnergyAmplifier,
        NovaAssaultedTheBarrel,
        NovaStrikeMagazine,
        PreciseGuidanceChip,
        PrecisionEnergyFocuser,
    }
    
    [Serializable]
    public class PropAttribute
    {
        //装备类型
        public PropType propType;
        //护盾加成百分比
        public float ShieldBonusPT;
        //投掷物伤害加成 百分比
        public float ProjectileDamageBonusPT;
        //子弹伤害加成 百分比
        public float BulletsDamageBonusPT;
        //暴击率 百分比
        public float CritRate;
        //暴击伤害 百分比
        public float CritDamage;
    }
    
    public class DataMgr: MonoBehaviour
    {
        public static DataMgr Instance;
        public ActiveDataSet ActiveDataSet;
        public HeroActiveDataSet HeroActiveDataSet;
        public float loadProgress;
        public Vector3 noisePos;
        public GameObject player;
        public PlayerCtrl playerCtrl;
        public bool getKey;
        public int remainMonster;
        public float charge;
        public int fixLight;
        public int nowLevel;
        public Dictionary<int,List<ActiveData>> activeDataDic=new Dictionary<int, List<ActiveData>>();
        
        public PlayerExtraAttribute playerExtraAttribute=new PlayerExtraAttribute();
        
        public void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        public void LoadData(Action<float> loadProgressCallBack=null)
        {
            Addressables.LoadAssetsAsync("ActiveDataSet", delegate(TextAsset asset)
            {
                ActiveDataSet=new ActiveDataSet(LoadJson(asset.text));
                foreach (var activeData in ActiveDataSet.DataList)
                {
                    if (!activeDataDic.ContainsKey(activeData.Level))
                    {
                        activeDataDic.Add(activeData.Level,new List<ActiveData>());
                    }
                    activeDataDic[activeData.Level].Add(activeData);
                }
                loadProgress += .5f;
                loadProgressCallBack?.Invoke(loadProgress);
            });
            Addressables.LoadAssetsAsync("HeroActiveDataSet", delegate(TextAsset asset)
            {
                HeroActiveDataSet=new HeroActiveDataSet(LoadJson(asset.text));
                loadProgress += .5f;
                loadProgressCallBack?.Invoke(loadProgress);
            });
        }
         
        public ActiveData GetEnemyData(string monsterName)
        {
            var level = nowLevel+1;
            return activeDataDic.TryGetValue(level, out var value) ? value.FirstOrDefault(activeData => activeData.Name == monsterName) : null;
        }
        
        static JSONNode LoadJson(string data)
        {
            return JSON.Parse(data);
        }
        
        public int GetShotDamage()
        {
            return HeroActiveDataSet[nowLevel].Atk;
        }
        
        public void ShowUpLevelPanel()
        {
            //展示选卡面板
            TipsMgr.Instance.ShowUpLevelPanel();
        }

        public void UpLevel(PropAttribute propAttribute)
        {
            playerExtraAttribute.Shields += propAttribute.ShieldBonusPT * player.GetComponent<Health>().CurrentHealth;
            //playerExtraAttribute.ProjectileDamage += propAttribute.ProjectileDamageBonusPT*;
            playerExtraAttribute.BulletsDamage += propAttribute.BulletsDamageBonusPT * HeroActiveDataSet[nowLevel].Atk;
            playerExtraAttribute.CritRate += propAttribute.CritRate;
            playerExtraAttribute.CritDamage += propAttribute.CritDamage;
            LoadLevel();
        }
        
        private void LoadLevel()
        {
            nowLevel++;
            SceneManager.LoadScene("Level1");
            DataMgr.Instance.getKey = false;
            DataMgr.Instance.charge = 0;
            DataMgr.Instance.fixLight = 0;
        }
        
    }
}