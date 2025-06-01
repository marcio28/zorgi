using System.ComponentModel.DataAnnotations;

namespace Zorgi.Api.ViewModels
{
    public class AssistidoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid CuidadorPrincipalId { get; private set; }

        [ScaffoldColumn(false)]
        public string NomeDoCuidadorPrincipal { get; protected set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataDeNascimento { get; private set; }

        [ScaffoldColumn(false)]
        public DateTime DataDeCadastro { get; set; }

        public IEnumerable<CuidadorViewModel> Cuidadores { get; set; }

        public IEnumerable<ReceitaMedicaViewModel> ReceitasMedicas { get; set; }
    }
}