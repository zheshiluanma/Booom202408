using UnityEngine;

namespace Manager
{
    public class TaskMgr : MonoBehaviour
    {
        public TaskType taskType;
        public static TaskMgr Instance;
        public void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        public void SetTask(TaskType taskType)
        {
            this.taskType = taskType;
        }
        
        public void StartMonsterTide(int totalMonster)
        {
            Debug.Log("Monster Tide Start");
            DataMgr.Instance.remainMonster = totalMonster;
        }
      
    }
    
    public enum TaskType
    {
        FindKey,
        MonsterTide,
        ObtainSample,
    }
}
