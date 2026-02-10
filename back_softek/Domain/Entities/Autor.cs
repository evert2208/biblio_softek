namespace back_softek.Domain.Entities
{
    public class Autor
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public DateTime fechaNac { get; set; }
        public string ciudadProcedencia { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
}
