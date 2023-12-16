using TP_PWEB.Models;
using System.ComponentModel.DataAnnotations;

namespace PWEB_TP.Models
{
    public class Arrendamento
    {
        [Key]
        public int IdArrendamentos { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int PeridoMinimoArrendamento { get; set; } //Dias

        public int ValorArrendamento { get; set; }

    }
}
