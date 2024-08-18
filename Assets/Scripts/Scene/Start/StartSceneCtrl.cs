using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene.Start
{
    public class StartSceneCtrl : MonoBehaviour
    {
        void Start()
        {
            DataMgr.Instance.LoadData(LoadProgress);
            //StartCoroutine(Refresh());
        }

        private  void LoadProgress(float progress)
        {
            if (progress > 0.95f)
            {
                TaskMgr.Instance.AddTask();
                EnterGame(DataMgr.Instance.GetRandomScene());
            }
        }

        public void EnterGame(string sceneName)
        {
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
        }
        
        int i = 0;
        
    }
}