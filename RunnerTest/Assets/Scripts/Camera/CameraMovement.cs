using UnityEngine;
using Scripts.Player;

namespace Scripts.Camera
{
    public class CameraMovement : IMovement
    {
        private CameraDataBase cameraData;
        private PlayerDataBase playerData;

        private Vector3 currVelocity;
        private Vector3 targetPos;

        public CameraMovement(CameraDataBase _cameraData,PlayerDataBase _playerData)
        {
            cameraData = _cameraData;
            playerData = _playerData;           
        }

        public void Move()
        {           
            targetPos = playerData.PlayerTransform.position + cameraData.Offset;
            targetPos.x = cameraData.CameraPos.position.x;
            cameraData.CameraPos.position = Vector3.SmoothDamp(cameraData.CameraPos.position, targetPos, ref currVelocity, cameraData.FollowSpeed);
        }
    }
}