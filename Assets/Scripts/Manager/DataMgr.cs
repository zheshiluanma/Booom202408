using System;
using Cfg.Data.Active;
using SimpleJSON;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Manager
{
    public class DataMgr: MonoBehaviour
    {
        public static DataMgr Instance;
        public ActiveDataSet ActiveDataSet;
        public float loadProgress;
        public Vector3 noisePos;
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
                loadProgress = 1;
                loadProgressCallBack?.Invoke(loadProgress);
            });
        }
         
         static JSONNode LoadJson(string data)
         {
             return JSON.Parse(data);
         }
    }
}