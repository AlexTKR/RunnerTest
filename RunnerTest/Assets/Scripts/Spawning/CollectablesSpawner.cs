using UnityEngine;
using System.Collections.Generic;
using Scripts.Pools;
using Scripts.Collectables;
using Scripts.Lane;

namespace Scripts.Spawning
{
    public class CollectablesSpawner : SpawnerBase
    {
        private LaneDataBase laneData;
        private CollectablesDataBase collectablesData;
        private CollectablesControllerBase collectablesController;
        private Transform holder;

        private GenericPool<CollectablesBase> collectablePool;
        private List<CollectablesBase> activeCollectableHolder;
        private List<Vector3> LanePos;

        public CollectablesSpawner(LaneDataBase _laneData, CollectablesDataBase _collectablesData, Transform _holder,
            CollectablesControllerBase _collectablesController)
        {
            laneData = _laneData;
            collectablesData = _collectablesData;
            collectablesController = _collectablesController;
            holder = _holder;
        }

        public override void Init()
        {
            InitCollectablePool();
            initLanePosHolder();
            InitActiveObstcHolder();
        }

        public override void CreateEntities()
        {
            CreateCollectables();
        }

        public override void Disable()
        {
            for (int i = 0; i < activeCollectableHolder.Count; i++)
            {
                activeCollectableHolder[i].gameObject.SetActive(false);
                collectablePool.SetInstance(activeCollectableHolder[i]);
            }
        }

        public override void Enable()
        {
            for (int i = 0; i < Random.Range(collectablesData.MinCollectablePerPlatform, collectablesData.MaxCollectablePerPlatform); i++)
            {
                CollectablesBase currCollectable = collectablePool.GetInctance();
                currCollectable.transform.localPosition = new Vector3(LanePos[Random.Range(0, LanePos.Count)].x, currCollectable.transform.position.y, Random.Range(-4, 5));
                currCollectable.gameObject.SetActive(true);
                activeCollectableHolder.Add(currCollectable);
            }
        }

        private void InitCollectablePool()
        {
            collectablePool = new CollectablesPool();
            collectablePool.InitiatePool();
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
            activeCollectableHolder = new List<CollectablesBase>();
        }

        private void CreateCollectables()
        {
            for (int i = 0; i < collectablesData.MaxCollectablePerPlatform; i++)
            {
                CollectablesBase coll = collectablesData.CollectableFactory.GetInstance();
                coll.SetCollectableController(collectablesController);
                coll.transform.SetParent(holder);
                collectablePool.SetInstance(coll);
            }
        }
    }
}