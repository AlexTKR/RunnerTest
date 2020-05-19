using UnityEngine;
using System.Collections.Generic;
using Scripts.Pools;
using Scripts.Obstacles;
using Scripts.Lane;

namespace Scripts.Spawning
{
    public class ObstacleSpawner : SpawnerBase
    {
        private LaneDataBase laneData;
        private ObstaclesDataBase obstaclesData;
        private Transform holder;

        private GenericPool<ObstacleBase> obstaclePool;
        private List<ObstacleBase> activeObstacleHolder; 
        private List<Vector3> LanePos;

        public ObstacleSpawner(LaneDataBase _laneData, ObstaclesDataBase _obstaclesData, Transform _holder)
        {
            laneData = _laneData;
            obstaclesData = _obstaclesData;
            holder = _holder;
        }

        public override void Init()
        {
            InitObstaclePool();
            initLanePosHolder();
            InitActiveObstcHolder();
        }

        public override void CreateEntities()
        {
            CreateObstacles();
        }

        public override void Disable()
        {
            for (int i = 0; i < activeObstacleHolder.Count; i++)
            {
                activeObstacleHolder[i].gameObject.SetActive(false);
                obstaclePool.SetInstance(activeObstacleHolder[i]);
            }
        }



        public override void Enable()
        {
            for (int i = 0; i < Random.Range(obstaclesData.MinObstaclePerPlatform, obstaclesData.MaxObstaclePerPlatform); i++)
            {
                ObstacleBase currObstacle = obstaclePool.GetInctance();
                currObstacle.transform.localPosition = new Vector3(LanePos[Random.Range(0, LanePos.Count)].x, currObstacle.transform.position.y, Random.Range(-4, 5));
                currObstacle.gameObject.SetActive(true);
                activeObstacleHolder.Add(currObstacle);
            }
        }

        private void InitObstaclePool()
        {
            obstaclePool = new ObstaclePool();
            obstaclePool.InitiatePool();
        }

        private void initLanePosHolder()
        {
            LanePos = new List<Vector3>();
            LanePos.Add(laneData.LeftLanePos);
            LanePos.Add(laneData.MiddleLanePos);
            LanePos.Add(laneData.RightLanePos);
        }

        private void InitActiveObstcHolder()
        {
            activeObstacleHolder = new List<ObstacleBase>();
        }

        private void CreateObstacles()
        {
            for (int i = 0; i < obstaclesData.MaxObstaclePerPlatform; i++)
            {
                ObstacleBase obstacle = obstaclesData.ObstacleFactory.GetInstance();
                obstacle.transform.SetParent(holder);
                obstaclePool.SetInstance(obstacle);
            }
        }
    }
}