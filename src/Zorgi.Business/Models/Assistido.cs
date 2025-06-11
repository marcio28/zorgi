 namespace Zorgi.Business.Models
{
    public class Assistido : Entity, IAggregateRoot
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public Guid CuidadorPrincipalId { get; set; }

        // EF Relation
        public Cuidador CuidadorPrincipal { get; set; }

        public IEnumerable<Cuidador> Cuidadores { get; set; } = [];

        public Assistido() { }
    }
}
