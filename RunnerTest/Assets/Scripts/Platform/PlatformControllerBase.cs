namespace Scripts.Platform
{

    public abstract class PlatformControllerBase 
    {
        public abstract void Init();
        public abstract void Tick();
        public abstract void PreSpawnPlatforms();
        public abstract void StartSpawningPlatforms();
        public abstract void StopSpawningPlatforms();
    }
}