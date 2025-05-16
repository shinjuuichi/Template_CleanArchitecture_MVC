namespace DataAccessLayer.Commons.Exceptions
{
    public class DataConflictException : Exception
    {
        public DataConflictException(Type entityType, string propertyName)
            : base($"This {propertyName} of {entityType.Name} has already been exist!") { }

        public DataConflictException(string? message) : base(message) { }
    }
}
