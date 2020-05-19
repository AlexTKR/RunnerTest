using UnityEngine;
using Scripts.Player;
using Scripts.GameState;
using Scripts.Lane;
using Scripts.Camera;
using Scripts.Platform;
using Scripts.Obstacles;
using Scripts.Collectables;
using Scripts.Screen;

namespace Scripts
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private PlayerDataBase playerData;
        [SerializeField] private LaneDataBase laneData;
        [SerializeField] private CameraDataBase cameraData;
        [SerializeField] private PlatformDataBase platformData;
        [SerializeField] private ObstaclesDataBase obstaclesData;
        [SerializeField] private CollectablesDataBase collectablesData;
        [SerializeField] private ScreenData screenData;

        private PlayerBase playerController;
        private LaneBase laneController;
        private GameStateBase gameState;
        private CameraBase cameraController;
        private PlatformControllerBase platformController;
        private ScreenBase screenController;
        private CollectablesControllerBase collectablesController;

        private void Awake()
        {
            InitScreenController();
            InitCollecrtableController();
            InitLane();
            InitPLayer();
            InitPlatform();
            InitCamera();
            InitGameState();
        }

        private void OnDisable()
        {
            collectablesController.Disable();
        }

        private void Update()
        {
            gameState?.Tick();
            playerController?.Tick();
            platformController?.Tick();
        }

        private void LateUpdate()
        {
            cameraController?.Tick();
        }

        private void InitScreenController()
        {
            screenController = new ScreenController(screenData);
        }

        private void InitLane()
        {
            laneController = new LaneController(laneData);
            laneController.Init();
        }

        private void InitPLayer()
        {
            playerController = new Player.Player(playerData, laneController, this, screenController);
            playerController.Init();
        }

        private void InitCollecrtableController()
        {
            collectablesController = new CollectablesController(screenData);
            collectablesController.Enable();
        }

        private void InitPlatform()
        {
            platformController = new PlatformController(platformData, playerData, laneData, obstaclesData, collectablesData, collectablesController);
            platformController.Init();
            platformController.PreSpawnPlatforms();
        }

        private void InitCamera()
        {
            cameraController = new CameraController(cameraData,playerData);
            cameraController.Init();
        }

        private void InitGameState()
        {
            gameState = new GameStateController(playerController, playerData ,platformController, this);
            gameState.Init();
        }
    }
}