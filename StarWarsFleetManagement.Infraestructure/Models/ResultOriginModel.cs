using System.Collections.Generic;

namespace StarWarsFleetManagement.Infrastructure.Models
{
    public class ResultOriginModel
    {
        public string Next { get; set; }
        public IEnumerable<StarshipOriginModel> Results { get; set; }
    }
}
