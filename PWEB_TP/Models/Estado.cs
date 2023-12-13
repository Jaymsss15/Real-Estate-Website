using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PWEB_TP.Models
{
    public class Estado
    {
        [Key]
        public int IdEstado { get; set; }

        public string TipoEstado { get; set; }

        [Display(Name = "Estado da Habitação", Prompt = "Introduza o Estado da Habitação", Description = "Descrição do Estado")]
        public string Descricao{ get; set; }
    }
}
