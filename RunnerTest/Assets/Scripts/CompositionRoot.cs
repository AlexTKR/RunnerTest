using UnityEngine;
using Scripts.Player;
using Scripts.GameState;

namespace Scripts
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private PlayerBase player;

        private GameStateBase gameState;

        private void Awake()
        {
            InitGameState();
        }

        private void Update()
        {
            gameState?.Tick();
            player?.Tick();
        }

        private void InitGameState()
        {
            gameState = new GameStateController(player);
            gameState.Init();
        }
    }
}