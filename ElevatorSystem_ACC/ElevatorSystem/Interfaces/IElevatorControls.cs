namespace ElevatorSystem.Interfaces
{
    public interface IElevatorControls
    {
        Task CallElevatorAsync(int floor);
        Task SelectFloorAsync(int floor);
    }
}
