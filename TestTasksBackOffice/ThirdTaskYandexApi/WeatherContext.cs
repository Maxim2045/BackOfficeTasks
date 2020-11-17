using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTaskYandexApi
{
    class WeatherContext:DbContext
    {
        public WeatherContext()
             : base("DbConnection")
        { }

        public DbSet<WeatherDB> Weathers { get; set; }
    }
}
