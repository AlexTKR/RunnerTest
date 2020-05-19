using Scripts.Lane;
using Scripts.Obstacles;
using Scripts.Spawning;

namespace Scripts.Platform
{
    public class Platform : PlatformBase
    {
        private LaneDataBase laneController;
        private ObstaclesDataBase obstaclesData;

        private SpawnerBase obstacleSpawner;

        public override void Init()
        {
            InitObstacleSpawner();
        }

        public override void DisablePlatform()
        {
            obstacleSpawner.Disable();
        }

        public override void EnablePlatform()
        {
            obstacleSpawner.Enable();
        }

        public override void SetLaneController(LaneDataBase _laneController)
        {
            laneController = _laneController;
        }

        public override void SetObstaclesData(ObstaclesDataBase _obstaclesData)
        {
            obstaclesData = _obstaclesData;
        }     

        private void InitObstacleSpawner()
        {
            obstacleSpawner = new ObstacleSpawner(laneController, obstaclesData, holder);
            obstacleSpawner.Init();
            obstacleSpawner.CreateEntities();
        }
    }
}