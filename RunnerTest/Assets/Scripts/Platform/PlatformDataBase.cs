using UnityEngine;
using Scripts.Factories;

namespace Scripts.Platform
{
    public abstract class PlatformDataBase : MonoBehaviour
    {
        public abstract PlatformFactory PlatformFactory { get; }
        public abstract Transform platformTransform { get; }
    }
}