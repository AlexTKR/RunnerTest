using UnityEngine;
using Scripts.Obstacles;

namespace Scripts.Factories
{
    public class ObstacleFactory : GenericFactory<ObstacleBase>
    {
        [SerializeField] private ObstacleBase obstaclePrefab;

        public override ObstacleBase GetInstance()
        {
            ObstacleBase newObstacle = Instantiate(obstaclePrefab);
            newObstacle.gameObject.SetActive(false);
            return newObstacle;
        }
    }
}