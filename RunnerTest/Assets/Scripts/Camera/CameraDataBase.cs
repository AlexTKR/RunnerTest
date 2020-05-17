using UnityEngine;

namespace Scripts.Camera
{
    public abstract class CameraDataBase : MonoBehaviour
    {
        public abstract Transform CameraPos { get; }
        public abstract Vector3 Offset { get; }
        public abstract float FollowSpeed { get; }
    }
}