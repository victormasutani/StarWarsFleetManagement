using StarWarsFleetManagement.Domain.Models;
using System.Collections.Generic;

namespace StarWarsFleetManagement.Application.Interfaces
{
    public interface IFleetManagementService
    {
        IEnumerable<Starship> GetStarships();
    }
}
