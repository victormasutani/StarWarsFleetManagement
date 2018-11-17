using StarWarsFleetManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsFleetManagement.Domain.Interfaces
{
    public interface IFleetManagementRepository
    {
        Task<IEnumerable<Starship>> GetStarshipsAsync();
    }
}
