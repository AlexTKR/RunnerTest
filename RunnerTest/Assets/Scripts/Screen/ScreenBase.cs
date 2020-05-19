using UnityEngine;

namespace Scripts.Screen
{
    public abstract class ScreenBase : MonoBehaviour
    {
        public abstract void SetDistance(float distance);
        public abstract void ResetDistance();
    }
}