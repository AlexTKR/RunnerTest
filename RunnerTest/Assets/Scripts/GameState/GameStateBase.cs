namespace Scripts.GameState
{
    public abstract class GameStateBase
    {
        public CurrentGameState currentGameState;

        public abstract void StartGame();
        public abstract void StopGame();
        public abstract void RestartGame();

        public abstract void Init();
        public abstract void Tick();
    }
}