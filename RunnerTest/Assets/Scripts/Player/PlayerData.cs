using System;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerData : PlayerDataBase
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 playerStartPos;
        [SerializeField] private float movingSpeed;
        [SerializeField] private float turningSpeed;

        public override CharacterController CharacterController => characterController;
        public override Transform PlayerTransform => playerTransform;
        public override float MovingSpeed => movingSpeed;
        public override float TurningSpeed => turningSpeed;
        public override Vector3 PlayerStartPos => playerStartPos;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            OnControllerHit?.Invoke(hit);
        }
    }
}