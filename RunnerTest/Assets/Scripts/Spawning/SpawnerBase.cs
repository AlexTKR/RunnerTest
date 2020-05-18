namespace Scripts.Spawning
{
    public abstract class SpawnerBase
    {
        public abstract void StartSpawning();
        public abstract void StopSpawning();
        public abstract void CreatePatforms();
        public abstract void Tick();
    }
}