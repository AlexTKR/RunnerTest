using Scripts.Player;
using Scripts.Spawning;
using Scripts.Pools;
using Scripts.Lane;
using Scripts.Obstacles;
using Scripts.Collectables;

namespace Scripts.Platform
{
    public class PlatformController : PlatformControllerBase
    {
        private PlayerDataBase playerData;
        private PlatformDataBase platformData;
        private LaneDataBase laneData;
        private ObstaclesDataBase obstaclesData;
        private CollectablesDataBase collectablesData;
        private CollectablesControllerBase collectablesController;

        private PlatformSpawnerBase platformSpawner;
        private GenericPool<PlatformBase> platformPool;

        private bool canSpawn = false;

        public PlatformController(PlatformDataBase _platformData, PlayerDataBase _playerData, LaneDataBase _laneData, ObstaclesDataBase
            _obstaclesData, CollectablesDataBase _collectablesData, CollectablesControllerBase _collectablesController)
        {
            playerData = _playerData;
            platformData = _platformData;
            laneData = _laneData;
            obstaclesData = _obstaclesData;
            collectablesData = _collectablesData;
            collectablesController = _collectablesController;
        }

        public override void Init()
        {
            initPlatformPool();
            InitPalatformSpawner();
        }

        public override void Tick()
        {
            if (canSpawn)
            {
                platformSpawner?.Tick();
            }
        }

        public override void StartSpawningPlatforms()
        {
            canSpawn = true;
        }

        public override void StopSpawningPlatforms()
        {
            canSpawn = false;
        }

        public override void PreSpawnPlatforms()
        {
            platformSpawner.CreatePatforms();
        }

        public override void ReStartPlatforms()
        {
            platformSpawner.RestartSpawn();
        }

        private void initPlatformPool()
        {
            platformPool = new PlatformPool();
            platformPool.InitiatePool();
        }

        private void InitPalatformSpawner()
        {
            platformSpawner = new PlatformSpawner(platformData, playerData, platformPool, laneData, obstaclesData, collectablesData, collectablesController);
        }
    }
}