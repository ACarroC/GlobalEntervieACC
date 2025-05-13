using ElevatorSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    public class ElevatorControlServices : IElevatorControls
    {
        private readonly IRequestCall _handler;

        public ElevatorControlServices(IRequestCall handler)
        {
            _handler = handler;
        }

        public Task CallElevatorAsync(int floor) => _handler.HandleExternalCallAsync(floor, true);
        public Task SelectFloorAsync(int floor) => _handler.HandleInternalRequestAsync(floor);
    }
}
