using UnityEngine;
using Scripts.Player;
using Scripts.GameState;
using Scripts.Lane;

namespace Scripts
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private PlayerDataBase playerData;
        [SerializeField] private LaneDataBase laneData;

        private PlayerBase playerController;
        private LaneBase laneController;
        private GameStateBase gameState;

        private void Awake()
        {
            InitLane();
            InitPLayer();
            InitGameState();
        }

        private void Update()
        {
            gameState?.Tick();
            playerController?.Tick();
        }

        private void InitGameState()
        {
            gameState = new GameStateController(playerController);
            gameState.Init();
        }

        private void InitPLayer()
        {
            playerController = new Player.Player(playerData, laneController ,this);
            playerController.Init();
        }

        private void InitLane()
        {
            laneController = new LaneController(laneData);
            laneController.Init();
        }
    }
}