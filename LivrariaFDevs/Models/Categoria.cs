namespace LivrariaFDevs.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public ICollection<Livro>? Livros { get; set; }
    }
}
