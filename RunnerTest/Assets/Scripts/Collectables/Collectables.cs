using UnityEngine;

namespace Scripts.Collectables
{
    public class Collectables : CollectablesBase
    {
        private CollectablesControllerBase collectablesController;
        private int playerLayer = 9;

        public override void SetCollectableController(CollectablesControllerBase _collectablesController)
        {
            collectablesController = _collectablesController;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == playerLayer)
            {
                collectablesController.OnCollected();
                gameObject.SetActive(false);
            }            
        }
    }
}