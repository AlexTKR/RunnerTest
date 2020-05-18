using Scripts.Player;
using Scripts.Spawning;
using Scripts.Pools;

namespace Scripts.Platform
{
    public class PlatformController : PlatformControllerBase
    {
        private PlayerDataBase playerData;
        private PlatformDataBase platformData;

        private SpawnerBase platformSpawner;
        private GenericPool<PlatformBase> platformPool;

        private bool canSpawn = false;

        public PlatformController(PlatformDataBase _platformData, PlayerDataBase _playerData)
        {
            playerData = _playerData;
            platformData = _platformData;
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

        private void initPlatformPool()
        {
            platformPool = new PlatformPool();
            platformPool.InitiatePool();
        }

        private void InitPalatformSpawner()
        {
            platformSpawner = new PlatformSpawner(platformData, playerData, platformPool);
        }

        public override void PreSpawnPlatforms()
        {
            platformSpawner.CreatePatforms();
        }
    }
}