namespace DataAccessLayer.Commons.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(Type entityType, int id)
            : base($"{entityType.Name} ({id}) was not found!") { }

        public DataNotFoundException(string? message) : base(message) { }
    }
}
