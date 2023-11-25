using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP_PWEB.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        public string Nome { get; set; }
    }
}
