namespace Scripts.Collectables
{
    public abstract class CollectablesControllerBase 
    {
        public abstract void OnCollected();
        public abstract void Enable();
        public abstract void Disable();
    }
}