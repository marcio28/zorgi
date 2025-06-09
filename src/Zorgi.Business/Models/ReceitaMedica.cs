namespace Zorgi.Business.Models
{
    public class ReceitaMedica : Entity
    {
        public Guid AssistidoId { get; set; }

        // EF Relation
        public Assistido Assistido { get; set; }

        public DateOnly DataDePrescricao { get; protected set; }

        public bool Ativa { get; set; }

        public string Imagem { get; set; }

        public ReceitaMedica() { }
    }
}
