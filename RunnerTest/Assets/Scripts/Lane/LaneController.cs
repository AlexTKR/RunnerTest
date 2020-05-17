using UnityEngine;

namespace Scripts.Lane
{
    public class LaneController : LaneBase
    {
        private LaneDataBase laneData;

        public override Vector3 LeftLane => laneData.LeftLanePos;

        public LaneController(LaneDataBase _laneData)
        {
            laneData = _laneData;
        }

        public override void Init()
        {
            currentLane = CurrentLane.MiddleLane;
        }

        public override Vector3 GetNextLanePos(NextLane nextLane)
        {
            if (nextLane == NextLane.GoLeft && currentLane != CurrentLane.Leftlane)
            {
                if (currentLane == CurrentLane.RightLane)
                {
                    currentLane = CurrentLane.MiddleLane;
                    return laneData.MiddleLanePos;
                }

                else
                {
                    currentLane = CurrentLane.Leftlane;
                    return laneData.LeftLanePos;
                }
            }

            else if (nextLane == NextLane.GoRight && currentLane != CurrentLane.RightLane)
            {
                if (currentLane == CurrentLane.Leftlane)
                {
                    currentLane = CurrentLane.MiddleLane;
                    return laneData.MiddleLanePos;
                }
                else
                {
                    currentLane = CurrentLane.RightLane;
                    return laneData.RightLanePos;
                }
            }
            else
            {
                return Vector3.zero;
            }

        }
    }
}