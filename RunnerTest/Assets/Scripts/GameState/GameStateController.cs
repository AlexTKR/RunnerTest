using UnityEngine;
using Scripts.InputReaders;
using Scripts.Player;
using Scripts.Platform;

namespace Scripts.GameState
{
    public class GameStateController : GameStateBase
    {
        private IInputReader gameStateInputReader;

        private PlayerBase player;
        private PlayerDataBase playerData;
        private PlatformControllerBase platformController;
        private MonoBehaviour mono;

        private string obstacleTag = "Obstacle";

        public GameStateController(PlayerBase _player, PlayerDataBase _playerData, PlatformControllerBase _platformController, MonoBehaviour _mono)
        {
            player = _player;
            mono = _mono;
            playerData = _playerData;
            platformController = _platformController;
        }

        public override void StartGame()
        {
            currentGameState = CurrentGameState.GameIsRunning;
            player.StartMoving();
            platformController.StartSpawningPlatforms();
        }

        public override void StopGame()
        {
            currentGameState = CurrentGameState.GameIsWaitinForRestart;
            player.StopMoving();
            platformController.StopSpawningPlatforms();
        }


        public override void RestartGame()
        {
            currentGameState = CurrentGameState.GameIsRunning;
            player.RestartPlayer();
            platformController.ReStartPlatforms();
            platformController.StartSpawningPlatforms();
            player.StartMoving();
        }

        public override void Init()
        {
            InitCurrentGameState();
            InitInputReader();
            Subscribe();
        }

        public override void Tick()
        {
            gameStateInputReader?.Read();
        }

        private void InitInputReader()
        {
            gameStateInputReader = new GameStateInpuReader(this);
        }

        private void InitCurrentGameState()
        {
            currentGameState = CurrentGameState.GameIsStopped;
        }

        private void Subscribe()
        {
            playerData.OnControllerHit += OnStopGame;
        }

        private void OnStopGame(ControllerColliderHit hit)
        {
            if (hit.collider.tag == obstacleTag)
            {
                StopGame();
            }
        }
    }
}