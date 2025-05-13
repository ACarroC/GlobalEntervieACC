using ElevatorSystem.Services;
using ElevatorSystem.Interfaces;
using Xunit;
using Moq;
using System.Threading.Tasks;

namespace ElevatorTest
{
    public class ElevatorTests
    {
        [Fact]
        public async Task ElevatorMovesToCallFloor()
        {
            var doorMock = new Mock<IElevatorDoorControls>();
            var elevator = new ElevatorSettingServices(doorMock.Object);

            await elevator.GoToFloorAsync(4);

            Assert.Equal(4, elevator.CurrentFloor);
        }
    }
}