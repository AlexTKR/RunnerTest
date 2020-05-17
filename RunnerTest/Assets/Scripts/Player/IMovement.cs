namespace Scripts.Player
{
    public interface IMovement 
    {
        void MoveLeft();
        void MoveRight();

        void Tick();
    }
}