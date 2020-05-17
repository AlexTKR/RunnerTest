using UnityEngine;

namespace Scripts.Lane
{
    public abstract class LaneBase 
    {
        public CurrentLane currentLane;
        public abstract Vector3 LeftLane { get; } 

        public abstract void Init();
        public abstract Vector3 GetNextLanePos(NextLane nextLane);
    }
}