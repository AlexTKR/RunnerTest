using UnityEngine;
using System;

namespace Scripts.Player
{
    public abstract class PlayerDataBase : MonoBehaviour
    {
        public abstract CharacterController CharacterController { get; }
        public abstract Transform PlayerTransform { get; }
        public abstract Vector3 PlayerStartPos { get; }
        public abstract float MovingSpeed { get; }
        public abstract float TurningSpeed { get; }

        public Action<ControllerColliderHit> OnControllerHit;
    }
}