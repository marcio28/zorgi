using FluentValidation;

namespace Zorgi.Business.Models.Validations
{
    public class AssistidoValidation : AbstractValidator<Assistido>
    {
        public AssistidoValidation()
        {
            ValidarNome();
        }

        private void ValidarNome()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido.")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
