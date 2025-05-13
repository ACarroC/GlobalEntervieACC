using ElevatorSystem.Interfaces;
using ElevatorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    public class ElevatorSettingServices : IElevatorSettings
    {
        private readonly IElevatorDoorControls _doorController;
        public int CurrentFloor { get; private set; } = 1;
        public ElevatorDirection Direction { get; private set; } = ElevatorDirection.Idle;
        public DoorState DoorState => _doorController.State;

        public ElevatorSettingServices(IElevatorDoorControls doorController)
        {
            _doorController = doorController;
        }

        public async Task GoToFloorAsync(int floor)
        {
            if (floor == CurrentFloor) return;

            Direction = floor > CurrentFloor ? ElevatorDirection.Up : ElevatorDirection.Down;
            Console.WriteLine($"Moviendo ascensor desde piso {CurrentFloor} hasta {floor}...");

            while (CurrentFloor != floor)
            {
                await Task.Delay(500);
                CurrentFloor += Direction == ElevatorDirection.Up ? 1 : -1;
                Console.WriteLine($"Piso actual: {CurrentFloor}");
            }

            Direction = ElevatorDirection.Idle;
            await _doorController.OpenAsync();
            await Task.Delay(2000); // Simula tiempo de espera en la planta
            await _doorController.CloseAsync();
        }

        public Task OpenDoorAsync() => _doorController.OpenAsync();
        public Task CloseDoorAsync() => _doorController.CloseAsync();
    }
}
