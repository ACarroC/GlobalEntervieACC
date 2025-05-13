using ElevatorSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Services
{
    public class RequestCallServices : IRequestCall
    {
        private readonly IElevatorSettings _elevator;
        private readonly Queue<int> _requests = new();

        public RequestCallServices(IElevatorSettings elevator)
        {
            _elevator = elevator;
        }

        public async Task HandleExternalCallAsync(int floor, bool goingUp)
        {
            _requests.Enqueue(floor);
            await ProcessQueueAsync();
        }

        public async Task HandleInternalRequestAsync(int floor)
        {
            _requests.Enqueue(floor);
            await ProcessQueueAsync();
        }

        private async Task ProcessQueueAsync()
        {
            while (_requests.Any())
            {
                int next = _requests.Dequeue();
                await _elevator.GoToFloorAsync(next);
            }
        }
    }
}
