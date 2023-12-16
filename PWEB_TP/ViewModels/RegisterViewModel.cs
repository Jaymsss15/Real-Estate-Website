using System.ComponentModel.DataAnnotations;

namespace PWEB_TP.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        [DataType(DataType.Password)]
        public string ConfirmacaoSenha { get; set; }

        [Required]
        public string PrimeiroNome { get; set; }

        [Required]
        public string UltimoNome { get; set; }

        [Required(ErrorMessage = "Selecione a role")]
        public string Role { get; set; }
    }
}
