namespace StarWarsFleetManagement.Console
{
    using Microsoft.Extensions.DependencyInjection;
    using StarWarsFleetManagement.Application.Interfaces;
    using StarWarsFleetManagement.Application.Services;
    using StarWarsFleetManagement.Domain.Interfaces;
    using StarWarsFleetManagement.Infrastructure.Repository;
    using System;
    using System.Configuration;
    using System.Linq;

    class Program
    {
        public static void Main(string[] args)
        {
            ServiceProvider serviceProvider = Configure();

            var _fleetManagementService = serviceProvider.GetService<IFleetManagementService>();

            Console.WriteLine("Calculator for resupply stops");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Distance to calculate (MGLT): ");
            var input = Console.ReadLine();

            long distance;

            if(!long.TryParse(input, out distance) || distance <= 0)
            {
                Console.WriteLine("Invalid input distance. Start again.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();

            var starships = _fleetManagementService.GetStarships();

            if (starships.Any())
            {
                Console.WriteLine("Starships:");
                foreach (var starship in starships)
                    Console.WriteLine($"{starship.Name}: {starship.CalculateAmountStopsRequired(distance)}");
            }
            else
                Console.WriteLine("None starships to calculte resupply stops.");

            Console.WriteLine("Done. Press a key to exit.");
            Console.ReadLine();
        }

        private static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddScoped<IFleetManagementService, FleetManagementService>()
                .AddHttpClient<IFleetManagementRepository, FleetManagementRepository>(client => client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrlApi"]))
                .Services.BuildServiceProvider();
        }
    }
}
