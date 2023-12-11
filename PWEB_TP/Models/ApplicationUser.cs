using Microsoft.AspNetCore.Identity;

namespace PWEB_TP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }

        //public DateTime DataNascimento { get; set; }

        //public int NIF { get; set; }

        // public ICollection<Arrendamento> Arrendamentos { get; set; }




        /*
                UserName = "admin@localhost.com",
                Email = "admin@localhost.com",
                PrimeiroNome = "Administrador",
                UltimoNome = "Local",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
        */
    }
}
