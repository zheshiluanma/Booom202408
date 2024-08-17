using Prop;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Manager
{
    public class TipsMgr : MonoBehaviour
    {
        public static TipsMgr Instance;
        public TMP_Text tipsText;
        
        public UpLevelPanel upLevelPanel;
        public void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        public void ShowTips(string tips)
        {
            Debug.Log(tips);
            tipsText.text = tips;
        }
        
        public void HideTips()
        {
            tipsText.text = "";
        }

        public void ShowUpLevelPanel()
        {
            upLevelPanel.Open();
        }
    }
}
