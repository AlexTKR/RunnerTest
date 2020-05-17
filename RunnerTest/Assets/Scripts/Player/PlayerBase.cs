using UnityEngine;

namespace Scripts.Player
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public abstract void StartMoving();
        public abstract void StopMoving();

        public abstract void Tick();
    }
}