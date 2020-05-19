using UnityEngine;
using Scripts.InputReaders;

namespace Scripts.GameState
{
    public class GameStateInpuReader : IInputReader
    {
        private GameStateBase gameState;

        public GameStateInpuReader(GameStateBase _gameState)
        {
            gameState = _gameState;
        }

        public void Read()
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameState.currentGameState == CurrentGameState.GameIsStopped)
            {
                gameState.StartGame();
            }

            else if (Input.GetKeyDown(KeyCode.Space) && gameState.currentGameState == CurrentGameState.GameIsWaitinForRestart)
            {
                gameState.RestartGame();
            }
        }
    }
}