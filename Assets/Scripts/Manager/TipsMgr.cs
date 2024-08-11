using TMPro;
using UnityEngine;

namespace Manager
{
    public class TipsMgr : MonoBehaviour
    {
        public static TipsMgr Instance;
        public TMP_Text tipsText;
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
    }
}
