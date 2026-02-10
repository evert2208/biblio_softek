namespace back_softek.Domain.Entities
{
    public class Libro
    {

        public int id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public int año { get; set; }
        public string genero { get; set; } = string.Empty;
        public int numeroPaginas { get; set; }
        public int autorId { get; set; }
        public Autor? autor { get; set; }
    }
}
