using UnityEngine;
using Scripts.Factories;

namespace Scripts.Collectables
{
    public class CollectablesData : CollectablesDataBase
    {
        [SerializeField] private CollectablesBase collectablePrefab;
        [SerializeField] private CollectableFactory collectableFactory;
        [SerializeField] private int minCollectablePerPlatform;
        [SerializeField] private int maxCollectablePerPlatform;

        public override CollectablesBase CollectablePrefab => collectablePrefab;
        public override CollectableFactory CollectableFactory => collectableFactory;
        public override int MinCollectablePerPlatform => minCollectablePerPlatform;
        public override int MaxCollectablePerPlatform => maxCollectablePerPlatform;
    }
}