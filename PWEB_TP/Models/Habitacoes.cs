using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_PWEB.Models
{
    public class Habitacoes
    {
        [Key]
        public int IdHabitacoes { get; set; }

        public string Localizacao { get; set; }

        public string? Tipo { get; set; }

        public int Preco { get; set; }

        public string? Disponivel { get; set; }

        public DateTime DataInicioContrato { get; set; }

        public DateTime DataFimContrato { get; set; }

        public string? Locador { get; set; }

        public int Avaliacao { get; set; }
        
        //Avalicao do Locador de 0 a 10

        //----Falta Periodo Min e Maximo de Arrendamento----

        //public DateTime DataInicioArrendamento { get; set; }

        // public DateTime DataFimArrendamento { get; set; }
    }
}
