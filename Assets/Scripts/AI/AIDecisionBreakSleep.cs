using Manager;
using MoreMountains.Tools;
using UnityEngine;

namespace AI
{
    public class AIDecisionBreakSleep : AIDecision
    {
        public float hearDistance = 2f;
        public override bool Decide()
        {
            return hearDistance >= CheckDistance();
        }

        private float CheckDistance()
        {
            //Debug.Log(Vector3.Distance(DataMgr.Instance.noisePos, _brain.gameObject.transform.position));
            return Vector3.Distance(DataMgr.Instance.noisePos, _brain.gameObject.transform.position);
        }
    }
}
