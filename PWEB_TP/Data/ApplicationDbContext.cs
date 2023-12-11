using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TP_PWEB.Models;
using PWEB_TP.Models;

namespace PWEB_TP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Habitacoes> Habitacoes { get; set; }
        public DbSet<ApplicationUser> ApplicationUser{ get; set; }

    }
}