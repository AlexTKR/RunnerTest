using UnityEngine;
using Scripts.Factories;

namespace Scripts.Collectables
{
    public abstract class CollectablesDataBase : MonoBehaviour
    {
        public abstract CollectablesBase CollectablePrefab { get; }
        public abstract CollectableFactory CollectableFactory { get; }
        public abstract int MinCollectablePerPlatform { get; }
        public abstract int MaxCollectablePerPlatform { get; }
    }
}