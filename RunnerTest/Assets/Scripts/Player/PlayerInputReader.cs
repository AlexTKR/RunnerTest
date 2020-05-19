using Scripts.InputReaders;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerInputReader : IInputReader
    {
        private IMovement playerMovement;

        public PlayerInputReader(IMovement _playerMovement)
        {
            playerMovement = _playerMovement;
        }

        public void Read()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerMovement.MoveLeft();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                playerMovement.MoveRight();
            }
        }
    }
}