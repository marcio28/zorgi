namespace zorgi.core.Models
{
    public class Cuidador : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        // EF Relation
        protected Cuidador() { }

        public Cuidador(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public void TrocarEmail(string email)
        {
            Email = email;
        }
    }
}
