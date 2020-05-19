using UnityEngine;
using Scripts.Factories;

namespace Scripts.Platform
{
    public class PlatformData : PlatformDataBase
    {
        [SerializeField] private PlatformFactory platformFactory;
        [SerializeField] private Transform platformHolder;
        [SerializeField] private Vector3 platformStartSpawnPos;
        [SerializeField] private float platformLenght;
        [SerializeField] private int platformCount;

        public override PlatformFactory PlatformFactory => platformFactory;
        public override Transform PlatformHolder => platformHolder;
        public override Vector3 PlatformStartSpawnPos => platformStartSpawnPos;
        public override float PlatformLenght => platformLenght;
        public override int PlatformCount => platformCount;
    }
}