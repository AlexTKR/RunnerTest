using UnityEngine;

namespace Scripts.Lane
{
    public abstract class LaneDataBase : MonoBehaviour
    {
        public abstract Vector3 LeftLanePos { get; }
        public abstract Vector3 MiddleLanePos { get; }
        public abstract Vector3 RightLanePos { get; }       
    }
}