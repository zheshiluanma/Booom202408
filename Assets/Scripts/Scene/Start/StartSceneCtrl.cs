using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene.Start
{
    public class StartSceneCtrl : MonoBehaviour
    {
        // Start is called before the first frame update
        // public TMP_Text loadText;
        // public GameObject hideGb;
        // public Button loadBtn;
        // public Button newGameBtn;
        // public Button exitGameBtn;
        // public bool refreshData;
        public string sceneName;
        void Start()
        {
            DataMgr.Instance.LoadData(LoadProgress);
            //StartCoroutine(Refresh());
        }

        private  void LoadProgress(float progress)
        {
            if (progress > 0.95f)
            {
                EnterGame(DataMgr.Instance.GetRandomScene());
            }
        }

        public void EnterGame(string sceneName)
        {
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
        }
        
        int i = 0;

        // private IEnumerator Refresh()
        // {
        //     while (DataMgr.Instance.loadProgress<1)
        //     {
        //         loadText.text ="加载数据中";
        //         for (var j = 0; j < i; j++)
        //         {
        //             loadText.text += ".";
        //         }
        //         i++;
        //         if (i > 3)
        //             i = 0;
        //         yield return new WaitForSeconds(1);
        //     }
        // }
    }
}