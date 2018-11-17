using StarWarsFleetManagement.Domain.Interfaces;
using StarWarsFleetManagement.Domain.Models;
using StarWarsFleetManagement.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsFleetManagement.Infrastructure.Repository
{
    public class FleetManagementRepository : IFleetManagementRepository
    {
        private readonly HttpClient _client;

        public FleetManagementRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Starship>> GetStarshipsAsync()
        {
            var startships = new List<StarshipOriginModel>();
            
            ResultOriginModel result = new ResultOriginModel { Next = "api/starships" };

            do
            {
                var response = await _client.GetAsync(result.Next);

                response.EnsureSuccessStatusCode();

                result = await response.Content.ReadAsAsync<ResultOriginModel>();
                startships.AddRange(result.Results);
            }
            while (!string.IsNullOrEmpty(result.Next));

            return MapToStarship(startships);
        }

        private IEnumerable<Starship> MapToStarship(IEnumerable<StarshipOriginModel> result) =>
            result.Select(s => new Starship(s.MGLT, s.Consumables, s.Name));
    }
}
