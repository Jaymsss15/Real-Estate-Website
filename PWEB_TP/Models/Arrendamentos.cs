using TP_PWEB.Models;

namespace PWEB_TP.Models
{
    public class Arrendamentos
    {
        public int Id { get; set; }
        //public string Cliente { get; set; } 
        public ApplicationUser Cliente { get; set; }

        public Habitacoes Habitacoes { get; set; }
    }
}
