using UnityEngine;
using Scripts.Factories;

namespace Scripts.Platform
{
    public abstract class PlatformDataBase : MonoBehaviour
    {
        public abstract PlatformFactory PlatformFactory { get; }
        public abstract Transform PlatformHolder { get; }
        public abstract Vector3 PlatformStartSpawnPos { get; }
        public abstract float PlatformLenght { get; }
        public abstract int PlatformCount { get; }
    }
}