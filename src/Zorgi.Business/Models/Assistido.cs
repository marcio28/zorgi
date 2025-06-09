 namespace Zorgi.Business.Models
{
    public class Assistido : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public Guid CuidadorPrincipalId { get; private set; }

        // EF Relation
        public Cuidador CuidadorPrincipal { get; protected set; }

        public IEnumerable<Cuidador> Cuidadores { get; } = [];

        public Assistido() { }

        public Assistido(Guid id, DateTime dataDeNascimento, Guid cuidadorPrincipalId)
        {
            Id = id;
            DataDeNascimento = dataDeNascimento;
            CuidadorPrincipalId = cuidadorPrincipalId;
        }
    }
}
