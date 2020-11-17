using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.Models
{
    class Product
    {
        public int Id { get; set; }

        public int PreparatId { get; set; }
        public Preparat Preparat { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int KindId { get; set; }
        public Kind Kind { get; set; }
        public float Weight { get; set; }
    }
}
