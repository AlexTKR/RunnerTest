using UnityEngine;
using System.Collections;
using Scripts.Lane;

namespace Scripts.Player
{
    public class PlayerMovement : IMovement
    {
        private PlayerDataBase playerData;
        private LaneBase laneController;
        private MonoBehaviour mono;

        private bool isMovingSideways = false;
        private float offset = 0.05f;

        public PlayerMovement(PlayerDataBase _playerData, LaneBase _laneController, MonoBehaviour _mono)
        {
            playerData = _playerData;
            laneController = _laneController;
            mono = _mono;
        }

        public void MoveLeft()
        {
            if (laneController.currentLane != CurrentLane.Leftlane && !isMovingSideways)
            {
                isMovingSideways = true;
                mono.StartCoroutine(MovePlayerLeft());
            }
        }

        public void MoveRight()
        {
            if (laneController.currentLane != CurrentLane.RightLane && !isMovingSideways)
            {
                isMovingSideways = true;
                mono.StartCoroutine(MovePlayerRight());
            }
        }

        public void Tick()
        {
            playerData.CharacterController.Move(Vector3.forward * Time.deltaTime * playerData.MovingSpeed);
        }

        private IEnumerator MovePlayerLeft()
        {
            Vector3 nextLanePos = laneController.GetNextLanePos(NextLane.GoLeft);
            float currTime = Time.time;

            while (playerData.PlayerTransform.position.x >= nextLanePos.x + offset)
            {
                Move(nextLanePos, currTime);
                yield return null;
            }

            isMovingSideways = false;
        }

        private IEnumerator MovePlayerRight()
        {
            Vector3 nextLanePos = laneController.GetNextLanePos(NextLane.GoRight);
            float currTime = Time.time;

            while (playerData.PlayerTransform.position.x <= nextLanePos.x - offset)
            {
                Move(nextLanePos, currTime);
                yield return null;
            }

            isMovingSideways = false;
        }

        private void Move(Vector3 nextLanePos, float currTime)
        {
            float timeMultiplier = Time.time - currTime;
            Vector3 playerPos = playerData.PlayerTransform.position;
            float turnSpeed = timeMultiplier * Time.deltaTime * playerData.TurningSpeed;
            playerPos.x = Mathf.Lerp(playerData.PlayerTransform.position.x, nextLanePos.x, turnSpeed);
            playerData.PlayerTransform.position = playerPos;
        }
    }
}