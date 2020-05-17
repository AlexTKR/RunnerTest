using Scripts.InputReaders;

namespace Scripts.Player
{
    public class PlayerInputReader : IInputReader
    {
        private IMovement playerMovement;

        public PlayerInputReader(IMovement _playerMovement)
        {
            playerMovement = _playerMovement;
        }

        public void Read()
        {
            
        }
    }
}