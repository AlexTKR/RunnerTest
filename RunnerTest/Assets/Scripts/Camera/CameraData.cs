using UnityEngine;

namespace Scripts.Camera
{
    public class CameraData : CameraDataBase
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Vector3 startPos;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float followSpeed;

        public override Transform CameraPos => cameraTransform;
        public override Vector3 Offset => offset;
        public override Vector3 StartPos => startPos;
        public override float FollowSpeed => followSpeed;
    }
}