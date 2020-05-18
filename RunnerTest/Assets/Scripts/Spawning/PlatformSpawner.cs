using UnityEngine;
using Scripts.Platform;
using Scripts.Player;
using Scripts.Pools;

namespace Scripts.Spawning
{
    public class PlatformSpawner : SpawnerBase
    {
        private PlatformDataBase platformData;
        private PlayerDataBase playerData;
        private GenericPool<PlatformBase> platformPool;

        private Vector3 currentPlatformPos;
        private float lastPlatformPos;

        public PlatformSpawner(PlatformDataBase _platformData, PlayerDataBase _playerData, GenericPool<PlatformBase> _platformPool)
        {
            platformData = _platformData;
            playerData = _playerData;
            platformPool = _platformPool;
        }

        public override void CreatePatforms()
        {
            currentPlatformPos = platformData.PlatformStartSpawnPos;

            for (int i = 0; i < platformData.PlatformCount; i++)
            {
                CreatePlatforms();
            }
        }

        public override void StartSpawning()
        {
            lastPlatformPos = platformData.PlatformStartSpawnPos.z;
        }

        public override void StopSpawning()
        {
            
        }

        public override void Tick()
        {
            if (playerData.PlayerTransform.position.z >= lastPlatformPos + platformData.PlatformLenght)
            {
                lastPlatformPos += platformData.PlatformLenght;
                PlatformBase currentPlatform = platformPool.GetInctance();
                currentPlatform.transform.position = Vector3.forward * currentPlatformPos.z;
                currentPlatformPos.z += platformData.PlatformLenght;
                platformPool.SetInstance(currentPlatform);
            }
        }

        private void CreatePlatforms()
        {
            PlatformBase currentPlatform = platformData.PlatformFactory.GetInstance();
            currentPlatform.transform.SetParent(platformData.PlatformHolder);
            currentPlatform.transform.position = Vector3.forward * currentPlatformPos.z;
            currentPlatformPos.z += platformData.PlatformLenght;
            currentPlatform.gameObject.SetActive(true);
            platformPool.SetInstance(currentPlatform);
        }
    }
}