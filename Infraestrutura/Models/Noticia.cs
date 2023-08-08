
using System.ComponentModel.DataAnnotations;

namespace Infraestrutura.Models
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Chapeu { get; set; }
        public DateTime DataPublicacao { get; set; }
        [Required]
        public string Autor { get; set; }
    }
}
