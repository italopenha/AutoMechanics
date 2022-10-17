using AutoMechanics.Models;
using AutoMechanics.SRC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace AutoMechanics.EFDBContext
{
    public class AutoMechanicsContext : DbContext
    {
        public AutoMechanicsContext(DbContextOptions<AutoMechanicsContext> options)
            : base(options) { }

        public DbSet<CarModel> Cars { get; set; }

        public DbSet<RepairModel> Repairs { get; set; }
    }
}
