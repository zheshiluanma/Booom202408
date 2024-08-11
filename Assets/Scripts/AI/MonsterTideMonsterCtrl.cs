using Manager;
using UnityEngine;

namespace AI
{
    public class MonsterTideMonsterCtrl : MonoBehaviour
    {
        public void OnKill()
        {
            DataMgr.Instance.remainMonster--;
        }
    }
}
