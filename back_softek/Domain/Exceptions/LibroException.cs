namespace back_softek.Domain.Exceptions
{
    public class LibroLimitMaxException : Exception
    {
        public LibroLimitMaxException()
           : base("No es posible registrar el libro, se alcanzó el máximo permitido")
        {
        }
    }

    public class LibrorNotFoundException : Exception
    {
        public LibrorNotFoundException()
           : base("El libro no está registrado")
        {
        }
    }
}
