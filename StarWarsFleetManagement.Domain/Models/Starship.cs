using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsFleetManagement.Domain.Models
{
    public class Starship
    {
        public Starship(string mGLT, string consumables, string name)
        {
            MGLT = mGLT;
            Consumables = consumables;
            Name = name;
        }

        public string MGLT { get; set; }
        public string Consumables { get; set; }
        public string Name { get; set; }

        public string CalculateAmountStopsRequired(long inputMGLT)
        {
            var mglt = GetMGLT();

            if (mglt == -1)
                return "unknown";

            var hours = GetHours();

            if (hours == -1)
                return "unknown";

            if (hours * mglt == 0)
                return "unknown";

            return (inputMGLT / (hours * mglt)).ToString();
        }

        private long GetMGLT()
        {
            var m = MGLT.ToLower().Split(' ');

            if (string.IsNullOrEmpty(m[0]))
                return -1;

            long number = -1;

            long.TryParse(m[0], out number);

            return number;
        }

        private long GetHours()
        {
            if (Consumables.ToLower() == "unknown")
                return -1;

            var cons = Consumables.ToLower().Split(' ');

            if (cons.Length < 2)
                return -1;

            long number;

            if (!long.TryParse(cons[0], out number))
                return -1;

            if (cons[1].Contains("hour"))
                return number;

            if (cons[1].Contains("day"))
                return number * 24;

            if (cons[1].Contains("week"))
                return number * 7 * 24;

            if (cons[1].Contains("month"))
                return number * 30 * 24;

            if (cons[1].Contains("year"))
                return number * 365 * 24;

            return -1;
        }
    }
}
