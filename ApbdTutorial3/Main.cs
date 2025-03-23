using System;
using System.Collections.Generic;
using ContainerShipManagement.Models;

class Program
{
    static void Main()
    {
        Console.WriteLine(" Welcome to the Container Ship Management System");
        
        // Creating a container ship
        Console.Write("Enter the ship name: ");
        string shipName = Console.ReadLine();

        Console.Write("Enter the max weight capacity of the ship (kg): ");
        double maxWeight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the max number of containers: ");
        int maxContainers = Convert.ToInt32(Console.ReadLine());

        ContainerShip ship = new ContainerShip(shipName, maxWeight, maxContainers);
        Console.WriteLine($"Ship '{shipName}' created successfully!\n");

        List<Container> containers = new List<Container>();

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Add Liquid Container");
            Console.WriteLine("2. Add Gas Container");
            Console.WriteLine("3. Add Refrigerated Container");
            Console.WriteLine("4. Load a Container onto the Ship");
            Console.WriteLine("5. Show Ship Details");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 6)
            {
                Console.WriteLine("Exiting program. Goodbye!");
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter container serial number (e.g., KON-L-1): ");
                    string liquidSerial = Console.ReadLine();

                    Console.Write("Enter tare weight (kg): ");
                    double liquidTare = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter max payload (kg): ");
                    double liquidMaxPayload = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Is this a hazardous liquid container? (yes/no): ");
                    bool isHazardous = Console.ReadLine().ToLower() == "yes";

                    LiquidContainer liquidContainer = new LiquidContainer(liquidSerial, liquidTare, liquidMaxPayload, isHazardous);
                    containers.Add(liquidContainer);
                    Console.WriteLine($"Liquid Container {liquidSerial} created!\n");
                    break;

                case 2:
                    Console.Write("Enter container serial number (e.g., KON-G-1): ");
                    string gasSerial = Console.ReadLine();

                    Console.Write("Enter tare weight (kg): ");
                    double gasTare = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter max payload (kg): ");
                    double gasMaxPayload = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter pressure (atm): ");
                    double gasPressure = Convert.ToDouble(Console.ReadLine());

                    GasContainer gasContainer = new GasContainer(gasSerial, gasTare, gasMaxPayload, gasPressure);
                    containers.Add(gasContainer);
                    Console.WriteLine($"Gas Container {gasSerial} created!\n");
                    break;

                case 3:
                    Console.Write("Enter container serial number (e.g., KON-C-1): ");
                    string refrigSerial = Console.ReadLine();

                    Console.Write("Enter tare weight (kg): ");
                    double refrigTare = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter max payload (kg): ");
                    double refrigMaxPayload = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter product type: ");
                    string productType = Console.ReadLine();

                    Console.Write("Enter temperature required (°C): ");
                    double temperature = Convert.ToDouble(Console.ReadLine());

                    RefrigeratedContainer refrigContainer = new RefrigeratedContainer(refrigSerial, refrigTare, refrigMaxPayload, productType, temperature);
                    containers.Add(refrigContainer);
                    Console.WriteLine($"Refrigerated Container {refrigSerial} created!\n");
                    break;

                case 4:
                    Console.WriteLine("Available Containers:");
                    for (int i = 0; i < containers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {containers[i].SerialNumber}");
                    }

                    Console.Write("Enter the container number to load onto the ship: ");
                    int containerIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (containerIndex >= 0 && containerIndex < containers.Count)
                    {
                        try
                        {
                            ship.LoadContainer(containers[containerIndex]);
                            Console.WriteLine($"Container {containers[containerIndex].SerialNumber} loaded onto the ship!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid container selection.");
                    }
                    break;

                case 5:
                    Console.WriteLine($"\n TShip: {ship.Name}");
                    Console.WriteLine($"Max Weight: {ship.MaxWeight} kg");
                    Console.WriteLine($"Max Containers: {ship.MaxContainers}");
                    Console.WriteLine($"Total Cargo Weight: {ship.TotalCargoWeight()} kg");
                    Console.WriteLine("Containers on board:");
                    foreach (var container in ship.Containers)
                    {
                        Console.WriteLine($"- {container.SerialNumber} | Cargo: {container.CargoMass} kg");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
