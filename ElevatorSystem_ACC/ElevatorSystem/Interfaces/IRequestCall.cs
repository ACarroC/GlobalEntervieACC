using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem.Interfaces
{
    public interface IRequestCall
    {
        Task HandleExternalCallAsync(int floor, bool goingUp);
        Task HandleInternalRequestAsync(int floor);
    }
}
