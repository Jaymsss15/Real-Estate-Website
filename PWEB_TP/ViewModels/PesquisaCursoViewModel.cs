using System.ComponentModel.DataAnnotations;
using TP_PWEB.Models;

namespace PWEB_TP.ViewModels
{
    public class PesquisaCursoViewModel
    {
        public List<Habitacoes> ListaDeHabitacoes { get; set; }
        public int NumResultados { get; set; }

        [Required]
        [Display(Name = "Texto", Prompt = "introduza o texto a pesquisar")]
        public string TextoAPesquisar { get; set; }
    }
}
