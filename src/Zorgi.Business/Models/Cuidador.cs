namespace Zorgi.Business.Models
{
    public class Cuidador : Entity, IAggregateRoot
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Email { get; set; }

        public decimal SalarioPorHora { get; set; }

        public string Foto { get; set; }

        public IEnumerable<Assistido> Assistidos { get; set; } = [];

        public Cuidador() { }
    }
}
