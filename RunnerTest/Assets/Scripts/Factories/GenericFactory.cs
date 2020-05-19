using UnityEngine;

namespace Scripts.Factories
{
    public abstract class GenericFactory <T> : MonoBehaviour where T : MonoBehaviour
    {
        public abstract T GetInstance();
    }
}