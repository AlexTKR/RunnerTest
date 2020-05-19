using UnityEngine;
using Scripts.Platform;
using Scripts.Player;
using Scripts.Pools;
using Scripts.Lane;
using Scripts.Obstacles;

namespace Scripts.Spawning
{
    public class PlatformSpawner : PlatformSpawnerBase
    {
        private PlatformDataBase platformData;
        private PlayerDataBase playerData;
        private GenericPool<PlatformBase> platformPool;
        private LaneDataBase laneData;
        private ObstaclesData obstaclesData;

        private Vector3 currentPlatformPos;
        private float lastPlatformPos;

        public PlatformSpawner(PlatformDataBase _platformData, PlayerDataBase _playerData, GenericPool<PlatformBase>
            _platformPool, LaneDataBase _laneData, ObstaclesData _obstaclesData)
        {
            platformData = _platformData;
            playerData = _playerData;
            platformPool = _platformPool;
            laneData = _laneData;
            obstaclesData = _obstaclesData;
        }

        public override void CreatePatforms()
        {
            currentPlatformPos = platformData.PlatformStartSpawnPos;
            lastPlatformPos = platformData.PlatformStartSpawnPos.z;

            for (int i = 0; i < platformData.PlatformCount; i++)
            {
                CreatePlatforms();
            }
        }

        public override void RestartSpawn()
        {
            lastPlatformPos = platformData.PlatformStartSpawnPos.z;
            currentPlatformPos = platformData.PlatformStartSpawnPos;

            for (int i = 0; i < platformPool.GetCount(); i++)
            {
                Spawn();
            }
        }

        public override void Tick()
        {
            SpawnPlatforms();
        }

        private void SpawnPlatforms()
        {
            if (playerData.PlayerTransform.position.z >= lastPlatformPos + platformData.PlatformLenght)
            {
                lastPlatformPos += platformData.PlatformLenght;
                Spawn();               
            }
        }

        private void Spawn()
        {            
            PlatformBase currentPlatform = platformPool.GetInctance();
            currentPlatform.DisablePlatform();
            currentPlatform.transform.position = Vector3.forward * currentPlatformPos.z;
            currentPlatformPos.z += platformData.PlatformLenght;
            currentPlatform.EnablePlatform();
            platformPool.SetInstance(currentPlatform);
        }

        private void CreatePlatforms()
        {
            PlatformBase currentPlatform = platformData.PlatformFactory.GetInstance();
            currentPlatform.SetLaneController(laneData);
            currentPlatform.SetObstaclesData(obstaclesData);
            currentPlatform.transform.SetParent(platformData.PlatformHolder);
            currentPlatform.transform.position = Vector3.forward * currentPlatformPos.z;
            currentPlatformPos.z += platformData.PlatformLenght;
            currentPlatform.gameObject.SetActive(true);
            currentPlatform.Init();
            currentPlatform.EnablePlatform();
            platformPool.SetInstance(currentPlatform);
        }
    }
}