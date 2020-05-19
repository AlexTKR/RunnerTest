using UnityEngine;
using Scripts.Factories;

namespace Scripts.Obstacles
{
    public abstract class ObstaclesDataBase : MonoBehaviour
    {
        public abstract ObstacleBase ObstaclePrefab { get; }
        public abstract ObstacleFactory ObstacleFactory { get; }
        public abstract int MinObstaclePerPlatform { get; }
        public abstract int MaxObstaclePerPlatform { get; }
    }
}