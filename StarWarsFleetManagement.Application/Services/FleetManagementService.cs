using StarWarsFleetManagement.Application.Interfaces;
using StarWarsFleetManagement.Domain.Interfaces;
using StarWarsFleetManagement.Domain.Models;
using System.Collections.Generic;

namespace StarWarsFleetManagement.Application.Services
{
    public class FleetManagementService : IFleetManagementService
    {
        private readonly IFleetManagementRepository _fleetManagementRepository;

        public FleetManagementService(IFleetManagementRepository fleetManagementRepository)
        {
            _fleetManagementRepository = fleetManagementRepository;
        }

        public IEnumerable<Starship> GetStarships() =>
            _fleetManagementRepository.GetStarshipsAsync().Result;
    }
}