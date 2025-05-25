using FluentValidation;

namespace Zorgi.Business.Models.Validations
{
    public class CuidadorValidation : AbstractValidator<Cuidador>
    {
        public CuidadorValidation()
        {
            ValidarNome();
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido.")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
