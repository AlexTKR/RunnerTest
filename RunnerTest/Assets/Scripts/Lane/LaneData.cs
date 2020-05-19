using UnityEngine;

namespace Scripts.Lane
{
    public class LaneData : LaneDataBase
    {
        [SerializeField] private Transform leftLanePos;
        [SerializeField] private Transform middleLanePos;
        [SerializeField] private Transform rightLanePos;

        public override Vector3 LeftLanePos => leftLanePos.position;
        public override Vector3 MiddleLanePos => middleLanePos.position;
        public override Vector3 RightLanePos => rightLanePos.position;
    }
}