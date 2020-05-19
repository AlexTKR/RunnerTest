using UnityEngine;

namespace Scripts.Player
{
    public abstract class PlayerBase 
    {
        public abstract void StartMoving();
        public abstract void StopMoving();
        public abstract void RestartPlayer();

        public abstract void Init();
        public abstract void Tick();
    }
}