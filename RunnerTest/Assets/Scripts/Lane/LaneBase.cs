using UnityEngine;

namespace Scripts.Lane
{
    public abstract class LaneBase : MonoBehaviour
    {
        public CurrentLane currentLane;
        public abstract Vector3 LeftLanePos { get; }
        public abstract Vector3 MiddleLanePos { get; }
        public abstract Vector3 RightLanePos { get; }

        public abstract void Init();        
    }
}