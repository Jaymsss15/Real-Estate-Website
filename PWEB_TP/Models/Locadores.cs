using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TP_PWEB.Models;

namespace PWEB_TP.Models
{
    public class Locadores
    {
        [Key]
        public int IdLocadores { get; set; }
        public string NomeLocador { get; set; }

        public string EstadoSubscricao { get; set; }

       // public string? Disponivel { get; set; }
    }
}
