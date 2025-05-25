using FluentValidation;
using FluentValidation.Results;
using Zorgi.Business.Models;
using Zorgi.Business.Notifications;

namespace Zorgi.Business.Services
{
    public abstract class BaseService(INotifier notifier)
    {
        private readonly INotifier _notifier = notifier;

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
