using ElevatorSystem.Interfaces;
using ElevatorSystem.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IElevatorDoorControls, ElevatorDoorControlServices>();
services.AddSingleton<IElevatorSettings, ElevatorSettingServices>();
services.AddSingleton<IRequestCall, RequestCallServices>();
services.AddSingleton<IElevatorControls, ElevatorControlServices>();

var provider = services.BuildServiceProvider();
var controller = provider.GetRequiredService<IElevatorControls>();

Console.WriteLine("Simulación de ascensor iniciada...");
while (true)
{
    Console.WriteLine("\nOpciones:");
    Console.WriteLine("1. Llamar ascensor desde una planta (1-5)");
    Console.WriteLine("2. Seleccionar piso dentro del ascensor (1-5)");
    Console.WriteLine("3. Salir");

    var option = Console.ReadLine();

    if (option == "1")
    {
        Console.Write("Ingrese planta (1-5): ");
        if (int.TryParse(Console.ReadLine(), out int floor))
            await controller.CallElevatorAsync(floor);
    }
    else if (option == "2")
    {
        Console.Write("Seleccione piso destino (1-5): ");
        if (int.TryParse(Console.ReadLine(), out int floor))
            await controller.SelectFloorAsync(floor);
    }
    else if (option == "3")
    {
        break;
    }
}