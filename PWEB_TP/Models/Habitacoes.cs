using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_PWEB.Models
{
    public class Habitacoes
    {
        [Key]
        public int IdHabitacoes { get; set; }

        public string Localizacao { get; set; }

        public string Tipo { get; set; }

        public int Preco { get; set; }

        public string Disponivel { get; set; }

        // Falta Nome e Avaliacao do Locador  // Falta Data Inicio, Data Fim Contrato de Arrendamento, Periodo Min e Maximo 
    }
}
