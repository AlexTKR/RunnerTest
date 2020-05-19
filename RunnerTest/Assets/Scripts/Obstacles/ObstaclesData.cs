using UnityEngine;
using Scripts.Factories;

namespace Scripts.Obstacles
{
    public class ObstaclesData : ObstaclesDataBase
    {
        [SerializeField] private ObstacleBase obstaclePrefab;
        [SerializeField] private ObstacleFactory obstacleFactory;
        [SerializeField] private int minObstaclePerPlatform;
        [SerializeField] private int maxObstaclePerPlatform;

        public override ObstacleBase ObstaclePrefab => obstaclePrefab;
        public override ObstacleFactory ObstacleFactory => obstacleFactory;
        public override int MinObstaclePerPlatform => minObstaclePerPlatform;
        public override int MaxObstaclePerPlatform => maxObstaclePerPlatform;
    }
}