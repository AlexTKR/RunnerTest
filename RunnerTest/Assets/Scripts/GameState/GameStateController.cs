using Scripts.InputReaders;
using Scripts.Player;

namespace Scripts.GameState
{
    public class GameStateController : GameStateBase
    {
        private IInputReader gameStateInputReader;

        private PlayerBase player;

        public GameStateController(PlayerBase _player)
        {
            player = _player;
        }

        public override void StartGame()
        {
            currentGameState = CurrentGameState.GameIsRunning;
            player.StartMoving();
        }

        public override void StopGame()
        {
            currentGameState = CurrentGameState.GameIsWaitinForRestart;
            player.StopMoving();
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