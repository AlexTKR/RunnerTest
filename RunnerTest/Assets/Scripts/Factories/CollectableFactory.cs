using UnityEngine;
using Scripts.Collectables;

namespace Scripts.Factories
{
    public class CollectableFactory : GenericFactory<CollectablesBase>
    {
        [SerializeField] private CollectablesBase collectablesPrefab;

        public override CollectablesBase GetInstance()
        {
            CollectablesBase newCollectable = Instantiate(collectablesPrefab);
            newCollectable.gameObject.SetActive(false);
            return newCollectable;
        }
    }
}