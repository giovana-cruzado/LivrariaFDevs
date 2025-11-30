using System.ComponentModel.DataAnnotations;

namespace LivrariaFDevs.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Nome { get; set; } = null!;
    }
}
