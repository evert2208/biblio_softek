namespace back_softek.Domain.Exceptions
{
    public class AutorNotFoundException : Exception
    {
        public AutorNotFoundException()
           : base("El autor no está registrado")
        {
        }
    }
}
