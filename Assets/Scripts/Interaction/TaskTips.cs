using Manager;
using TMPro;
using UnityEngine;

namespace Interaction
{
    public class TaskTips : MonoBehaviour
    {
        public TaskData taskData;
        public TMP_Text taskTipsText;
    
        public void IntStart(TaskData data)
        {
            taskData = data;
            taskTipsText=GetComponent<TMP_Text>();
            UpdateProgress(0);
        }
    
        public void UpdateProgress(int progress)
        {
            taskTipsText.text = "["+taskData.taskDescription + " " + progress + "/" + taskData.maxProgress+"]";
        }
    }
}
