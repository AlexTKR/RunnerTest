using Scripts.Lane;
using Scripts.Obstacles;
using Scripts.Collectables;
using Scripts.Spawning;

namespace Scripts.Platform
{
    public class Platform : PlatformBase
    {
        private LaneDataBase laneController;
        private ObstaclesDataBase obstaclesData;
        private CollectablesDataBase collectablesData;
        private CollectablesControllerBase collectablesController;

        private SpawnerBase obstacleSpawner;
        private SpawnerBase collectablesSpawner;

        public override void Init()
        {
            InitObstacleSpawner();
            InitCollectablesSpawner();
        }

        public override void DisablePlatform()
        {
            obstacleSpawner.Disable();
            collectablesSpawner.Disable();
        }

        public override void EnablePlatform()
        {
            obstacleSpawner.Enable();
            collectablesSpawner.Enable();
        }

        public override void SetLaneController(LaneDataBase _laneController)
        {
            laneController = _laneController;
        }

        public override void SetObstaclesData(ObstaclesDataBase _obstaclesData)
        {
            obstaclesData = _obstaclesData;
        }

        public override void SetCollectablesController(CollectablesControllerBase _collectablesController)
        {
            collectablesController = _collectablesController;
        }

        public override void SetCollectablesData(CollectablesDataBase _collectablesData)
        {
            collectablesData = _collectablesData;
        }

        private void InitObstacleSpawner()
        {
            obstacleSpawner = new ObstacleSpawner(laneController, obstaclesData, holder);
            obstacleSpawner.Init();
            obstacleSpawner.CreateEntities();
        }

        private void InitCollectablesSpawner()
        {
            collectablesSpawner = new CollectablesSpawner(laneController, collectablesData, holder, collectablesController);
            collectablesSpawner.Init();
            collectablesSpawner.CreateEntities();
        }
    }
}