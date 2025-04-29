namespace CoPilot.Workshop.Framework
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; } = [];

        public ValidationException(string message)
            : this(string.Empty, message)
        {
        }

        public ValidationException(string propName, string message) : base(message)
        {
            Errors.TryAdd(propName, [message]);
        }

        public ValidationException(Dictionary<string, string[]> errors)
            : base("Validation failed.")
        {
            Errors = errors;
        }
    }
}
