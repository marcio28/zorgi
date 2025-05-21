namespace zorgi.core.Models
{
    public class Cuidador : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public decimal SalarioPorHora { get; private set; }

        // EF Relation
        public Cuidador() { }

        public Cuidador(Guid id, string nome, string email, decimal salarioPorHora)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SalarioPorHora = salarioPorHora;
        }

        public void TrocarEmail(string email)
        {
            Email = email;
        }

        public void TrocarSalarioPorHora(decimal salarioPorHora)
        {
            SalarioPorHora = salarioPorHora;
        }

    }
}
