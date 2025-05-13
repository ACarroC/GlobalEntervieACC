using ElevatorSystem.Models;

namespace ElevatorSystem.Interfaces
{
    public interface IElevatorDoorControls
    {
        DoorState State { get; }
        Task OpenAsync();
        Task CloseAsync();
    }
}
