using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTask.Models;

namespace FirstTask
{
    class MedicineContext:DbContext
    {
        public MedicineContext()
            : base("DbConnection")
        { }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Preparat> Preparats { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
