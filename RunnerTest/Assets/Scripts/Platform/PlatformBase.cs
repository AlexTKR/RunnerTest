using UnityEngine;
using Scripts.Lane;
using Scripts.Obstacles;

namespace Scripts.Platform
{
    public abstract class PlatformBase : MonoBehaviour
    {
        [SerializeField] protected Transform holder;

        public abstract void SetLaneController(LaneDataBase _laneController);
        public abstract void SetObstaclesData(ObstaclesDataBase _obstaclesData);

        public abstract void Init();
        public abstract void EnablePlatform();
        public abstract void DisablePlatform();
    }
}