namespace Scripts.Spawning
{
    public abstract class  SpawnerBase 
    {
        public abstract void Init();
        public abstract void CreateEntities();
        public abstract void Enable();
        public abstract void Disable();
    }
}