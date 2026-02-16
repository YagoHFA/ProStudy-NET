namespace ProStudy_NET.Component.Exceptions.Models
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
            
        }
    }
}