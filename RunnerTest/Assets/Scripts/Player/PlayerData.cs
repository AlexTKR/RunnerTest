using UnityEngine;

namespace Scripts.Player
{
    public class PlayerData : PlayerDataBase
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] Transform playerTransform;
        [SerializeField] private float movingSpeed;
        [SerializeField] private float turningSpeed;

        public override CharacterController CharacterController => characterController;
        public override Transform PlayerTransform => playerTransform;
        public override float MovingSpeed => movingSpeed;
        public override float TurningSpeed => turningSpeed;
    }
}