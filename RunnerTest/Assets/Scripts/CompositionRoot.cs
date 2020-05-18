using UnityEngine;
using Scripts.Player;
using Scripts.GameState;
using Scripts.Lane;
using Scripts.Camera;
using Scripts.Platform;

namespace Scripts
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private PlayerDataBase playerData;
        [SerializeField] private LaneDataBase laneData;
        [SerializeField] private CameraDataBase cameraData;
        [SerializeField] private PlatformDataBase platformData;

        private PlayerBase playerController;
        private LaneBase laneController;
        private GameStateBase gameState;
        private CameraBase cameraController;

        private void Awake()
        {
            InitLane();
            InitPLayer();
            InitCamera();
            InitGameState();
        }

        private void Update()
        {
            gameState?.Tick();
            playerController?.Tick();
        }

        private void LateUpdate()
        {
            cameraController?.Tick();
        }

        private void InitLane()
        {
            laneController = new LaneController(laneData);
            laneController.Init();
        }

        private void InitPLayer()
        {
            playerController = new Player.Player(playerData, laneController, this);
            playerController.Init();
        }

        private void InitCamera()
        {
            cameraController = new CameraController(cameraData,playerData);
            cameraController.Init();
        }

        private void InitGameState()
        {
            gameState = new GameStateController(playerController);
            gameState.Init();
        }
    }
}