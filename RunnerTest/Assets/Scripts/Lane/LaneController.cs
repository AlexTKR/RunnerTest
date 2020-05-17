using UnityEngine;

namespace Scripts.Lane
{
    public class LaneController : LaneBase
    {
        [SerializeField] private Transform leftLanePos;
        [SerializeField] private Transform middleLanePos;
        [SerializeField] private Transform rightLanePos;

        public override Vector3 LeftLanePos => leftLanePos.position;
        public override Vector3 MiddleLanePos => middleLanePos.position;
        public override Vector3 RightLanePos => rightLanePos.position;

        public override void Init()
        {
            currentLane = CurrentLane.MiddleLane;
        }
    }
}