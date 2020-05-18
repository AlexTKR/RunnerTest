using UnityEngine;
using Scripts.Factories;

namespace Scripts.Platform
{
    public class PlatformData : PlatformDataBase
    {
        [SerializeField] private PlatformFactory platformFactory;
        [SerializeField] private Transform platformHolder;

        public override PlatformFactory PlatformFactory => platformFactory;
        public override Transform platformTransform => platformHolder;
    }
}