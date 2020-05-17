using UnityEngine;
using Scripts.InputReaders;

namespace Scripts.Player
{
    public class Player : PlayerBase
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float playerSpeed;

        private IInputReader playerInputReader;
        private IMovement playerMovement;

        private bool canMove = false;

        private void Awake()
        {
            InitMovement();
            InitInputReader();
        }

        public override void Tick()
        {
            if (canMove)
            {
                playerInputReader.Read();
                playerMovement.Tick();
            }
        }

        public override void StartMoving()
        {
            canMove = true;
        }

        public override void StopMoving()
        {
            canMove = false;
        }

        private void InitInputReader()
        {
            playerInputReader = new PlayerInputReader(playerMovement);
        }

        private void InitMovement()
        {
            playerMovement = new PlayerMovement(characterController, playerSpeed);
        }

    }
}