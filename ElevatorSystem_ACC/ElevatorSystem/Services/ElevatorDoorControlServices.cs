using ElevatorSystem.Interfaces;
using ElevatorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    public class ElevatorDoorControlServices : IElevatorDoorControls
    {
        public DoorState State { get; private set; } = DoorState.Closed;

        public async Task OpenAsync()
        {
            Console.WriteLine("Abriendo puertas...");
            await Task.Delay(1000);
            State = DoorState.Open;
            Console.WriteLine("Puertas abiertas.");
        }

        public async Task CloseAsync()
        {
            Console.WriteLine("Cerrando puertas...");
            await Task.Delay(1000);
            State = DoorState.Closed;
            Console.WriteLine("Puertas cerradas.");
        }
    }
}
