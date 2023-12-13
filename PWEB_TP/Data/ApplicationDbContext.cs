using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP_PWEB.Models;
using PWEB_TP.Models;

namespace PWEB_TP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Habitacoes> Habitacoes { get; set; }
        public DbSet<Locadores> Locadores { get; set; }

        public DbSet<Arrendamento> Arrendamento { get; set; }
    }
}