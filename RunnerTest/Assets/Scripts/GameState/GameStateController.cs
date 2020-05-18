using Scripts.InputReaders;
using Scripts.Player;
using Scripts.Platform;

namespace Scripts.GameState
{
    public class GameStateController : GameStateBase
    {
        private IInputReader gameStateInputReader;

        private PlayerBase player;
        private PlatformControllerBase platformController;

        public GameStateController(PlayerBase _player, PlatformControllerBase _platformController)
        {
            player = _player;
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
        }

        public override void Init()
        {
            InitCurrentGameState();
            InitInputReader();
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
    }
}