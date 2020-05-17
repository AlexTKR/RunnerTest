using Scripts.Player;

namespace Scripts.Camera
{
    public class CameraController : CameraBase
    {
        private CameraDataBase cameraData;
        private PlayerDataBase playerData;
        private IMovement cameraMovement;

        public CameraController(CameraDataBase _cameraData, PlayerDataBase _playerData)
        {
            cameraData = _cameraData;
            playerData = _playerData;
        }

        public override void Init()
        {
            InitCameraMovement();
        }

        public override void Tick()
        {
            cameraMovement?.Move();
        }

        private void InitCameraMovement()
        {
            cameraMovement = new CameraMovement(cameraData,playerData);
        }
    }
}