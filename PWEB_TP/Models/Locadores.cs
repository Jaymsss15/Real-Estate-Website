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

        [Display(Name = "Estado da Subscrição", Prompt = "Introduza o Estado da Subscrição", Description = "Descrição do Estado da Subscrição")]
        public string EstadoSubscricao { get; set; }

       // public string? Disponivel { get; set; }

        public ICollection<Habitacoes> Habitacoes { get; set; }
    }
}
