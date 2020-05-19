using UnityEngine;

namespace Scripts.Collectables
{
    public abstract class CollectablesBase : MonoBehaviour
    {
        public abstract void SetCollectableController(CollectablesControllerBase collectablesController);
    }
}