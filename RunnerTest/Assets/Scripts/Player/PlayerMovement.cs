using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement : IMovement
    {
        private CharacterController characterController;
        private float speed;

        public PlayerMovement(CharacterController _characterController, float _speed)
        {
            characterController = _characterController;
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