namespace Zorgi.Business.Models
{
    public class Cuidador : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public decimal SalarioPorHora { get; private set; }
        public IEnumerable<Assistido> Assistidos { get; } = [];

        public Cuidador() { }
        public Cuidador(Guid id, string documento, string nome, string email, decimal salarioPorHora)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
            SalarioPorHora = salarioPorHora;
        }

        public void TrocarNome(string nome)
        {
            Nome = nome;
        }

        public void TrocarDocumento(string documento)
        {
            Documento = documento;
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
