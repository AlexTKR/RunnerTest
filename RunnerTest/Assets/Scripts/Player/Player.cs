using UnityEngine;
using Scripts.InputReaders;
using Scripts.Lane;
using Scripts.Screen;

namespace Scripts.Player
{
    public class Player : PlayerBase
    {
        private PlayerDataBase playerData;
        private LaneBase laneController;
        private MonoBehaviour mono;
        private ScreenBase screenController;
        private IInputReader playerInputReader;
        private IMovement playerMovement;

        private bool canMove = false;

        public Player(PlayerDataBase _playerData, LaneBase _laneController, MonoBehaviour _mono, ScreenBase _screenController)
        {
            playerData = _playerData;
            laneController = _laneController;
            mono = _mono;
            screenController = _screenController;
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
            playerData.CharacterController.transform.position = playerData.PlayerStartPos;
            screenController.ResetDistance();
            Physics.SyncTransforms();
        }

        private void InitMovement()
        {
            playerMovement = new PlayerMovement(playerData, laneController, mono, screenController);
        }

        private void InitInputReader()
        {
            playerInputReader = new PlayerInputReader(playerMovement);
        }
    }
}