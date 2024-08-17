using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class TaskMgr : MonoBehaviour
    {
        public TaskType taskType;
        public static TaskMgr Instance;
        public Dictionary<string,TaskTips> nowTasks=new ();
        public List<TaskData> taskDatas=new List<TaskData>()
        {
            //0
            new TaskData()
            {
                taskDescription= "获取A14层权限密钥"
            },
            //1
            new TaskData()
            {
                taskDescription= "重启并校准主控系统"
            },
            //2
            new TaskData()
            {
                taskDescription= "寻找A14层管理员"
            },
            //3
            new TaskData()
            {
                taskDescription= "次级:获取A14层权限密钥"
            },
            //4
            new TaskData()
            {
                taskDescription= "次级:重启并校准主控系统"
            },
            //5
            new TaskData()
            {
                taskDescription= "前往A18区实验室"
            },
            //6
            new TaskData()
            {
                taskDescription= "部署巢穴勘探器"
            },
            //7
            new TaskData()
            {
                taskDescription= "收集巢穴生物样本",
                maxProgress=100
            },
            //8
            new TaskData()
            {
                taskDescription= "修复能源系统",
                maxProgress=4
            },
            //9
            new TaskData()
            {
                taskDescription= "获取A17层权限密钥"
            },
            //10
            new TaskData()
            {
                taskDescription= "重启并校准主控系统"
            },
            //11
            new TaskData()
            {
                taskDescription= "寻找下行电梯"
            },
            //12
            new TaskData()
            {
                taskDescription = "前往信号发射地"
            }
          
        };
        
        public GameObject taskPanelPrefab;
        public Transform taskPanel;
        
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

        public void AddTask()
        {
            switch (DataMgr.Instance.nowLevel)
            {
                case 0:
                {
                    AddTask("GetKey14",0);
                    AddTask("Reboot14",1);
                    break;
                }
                case 1:
                {
                    AddTask("SetMachine",6);
                    AddTask("CollectSample",7);
                    AddTask("Go18",5);
                    break;
                }
                case 2:
                {
                    AddTask("FixLight",8);
                    break;
                }
                case 3:
                {
                    AddTask("GetKey17",9);
                    AddTask("Reboot17",10);
                    break;
                }
                case 4:
                {
                    break;
                }
            }
        }
        
        public void AddTask(string key,int index)
        {
            var tasktips = Instantiate(taskPanelPrefab, taskPanel);
            tasktips.GetComponent<TaskTips>().IntStart(taskDatas[index]);
            nowTasks.Add(key, tasktips.GetComponent<TaskTips>());
        }
        
        public void CompleteTask(string key,int completeProgress=1)
        {
            nowTasks[key].UpdateProgress(completeProgress);
            if (completeProgress >= nowTasks[key].taskData.maxProgress)
            {
                nowTasks[key].taskData.isComplete = true;
            }
        }
        
        public void ClearTask()
        {
            for (int i = taskPanel.childCount-1; i >=0 ; i--)
            {
                Destroy(taskPanel.GetChild(i).gameObject);
            }
        }
    }
    
    public enum TaskType
    {
        FindKey,
        MonsterTide,
        ObtainSample,
    }
    
    public class TaskData
    {
        public TaskType taskType;
        public string taskName;
        public string taskDescription;
        public bool isComplete;
        public int maxProgress=1;
        public int currentProgress=0;
    }
}