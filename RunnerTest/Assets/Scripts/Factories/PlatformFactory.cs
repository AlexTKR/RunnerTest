using UnityEngine;
using Scripts.Platform;

namespace Scripts.Factories
{
    public class PlatformFactory : GenericFactory<PlatformBase>
    {
        [SerializeField] private PlatformBase platform;

        public override PlatformBase GetInstance()
        {
            PlatformBase newPlatform = Instantiate(platform);
            newPlatform.gameObject.SetActive(false);
            return newPlatform;
        }
    }
}