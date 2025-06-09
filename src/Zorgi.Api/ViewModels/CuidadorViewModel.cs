using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zorgi.Api.ViewModels
{
    public class CuidadorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Email { get; set; }

        public decimal SalarioPorHora { get; set; }

        public IEnumerable<AssistidoViewModel> Assistidos { get; set; }
    }
}
