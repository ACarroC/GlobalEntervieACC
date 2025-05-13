using ElevatorSystem.Models;

namespace ElevatorSystem.Interfaces
{
    public interface IElevatorSettings
    {
        int CurrentFloor { get; }
        ElevatorDirection Direction { get; }
        DoorState DoorState { get; }

        Task GoToFloorAsync(int floor);
        Task OpenDoorAsync();
        Task CloseDoorAsync();
    }
}
