using System.ComponentModel.DataAnnotations;

namespace Zorgi.Api.ViewModels
{
    public class CuidadorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 11)]
        public string Documento { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; private set; }

        public decimal SalarioPorHora { get; private set; }

        public IEnumerable<AssistidoViewModel> Assistidos { get; set; }
    }
}
