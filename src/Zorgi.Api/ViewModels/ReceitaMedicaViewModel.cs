using System.ComponentModel.DataAnnotations;

namespace Zorgi.Api.ViewModels
{
    public class ReceitaMedicaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public bool Ativa { get; set; }

        public string ImagemUpload { get; set; }

        public string Imagem { get; set; }
    }
}
