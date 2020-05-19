using UnityEngine;
using Scripts.Lane;
using Scripts.Obstacles;
using Scripts.Collectables;

namespace Scripts.Platform
{
    public abstract class PlatformBase : MonoBehaviour
    {
        [SerializeField] protected Transform holder;

        public abstract void SetLaneController(LaneDataBase _laneController);
        public abstract void SetObstaclesData(ObstaclesDataBase _obstaclesData);
        public abstract void SetCollectablesData(CollectablesDataBase _collectablesData);
        public abstract void SetCollectablesController(CollectablesControllerBase _collectablesController);

        public abstract void Init();
        public abstract void EnablePlatform();
        public abstract void DisablePlatform();
    }
}