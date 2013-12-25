using Peregrin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peregrin.Services.Model
{
    public static class SupportedCities
    {       
        public static IEnumerable<City> GetSupportedCities()
        {
            return new List<City>
            {
                new City()
                {
                    Name = "Wroclaw",
                    ImageUrl = "Assets/Images/Arms/wroclaw.png"
                }
            };
        }

    }
}
