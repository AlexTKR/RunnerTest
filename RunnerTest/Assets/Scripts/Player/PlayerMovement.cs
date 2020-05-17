using UnityEngine;
using Scripts.Lane;

namespace Scripts.Player
{
    public class PlayerMovement : IMovement
    {
        private CharacterController characterController;
        private LaneBase laneController;
        private float speed;

        public PlayerMovement(CharacterController _characterController, LaneBase _laneController , float _speed)
        {
            characterController = _characterController;
            laneController = _laneController;
            speed = _speed;
        }

        public void MoveLeft()
        {
            
        }

        public void MoveRight()
        {
            
        }

        public void Tick()
        {
            characterController.Move(Vector3.forward * Time.deltaTime * speed);
        }
    }
}