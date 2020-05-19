using UnityEngine;
using Scripts.InputReaders;
using Scripts.Lane;

namespace Scripts.Player
{
    public class Player : PlayerBase
    {
        private PlayerDataBase playerData;
        private LaneBase laneController;
        private MonoBehaviour mono;
        private IInputReader playerInputReader;
        private IMovement playerMovement;

        private bool canMove = false;

        public Player(PlayerDataBase _playerData, LaneBase _laneController, MonoBehaviour _mono)
        {
            playerData = _playerData;
            laneController = _laneController;
            mono = _mono;
        }

        public override void Init()
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

        public override void RestartPlayer()
        {
            playerData.CharacterController.transform.position = new Vector3(0, 1, 0);
            Physics.SyncTransforms();
        }

        private void InitMovement()
        {
            playerMovement = new PlayerMovement(playerData, laneController, mono);
        }

        private void InitInputReader()
        {
            playerInputReader = new PlayerInputReader(playerMovement);
        }
    }
}