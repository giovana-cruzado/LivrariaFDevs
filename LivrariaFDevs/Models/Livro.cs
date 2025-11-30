namespace LivrariaFDevs.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
