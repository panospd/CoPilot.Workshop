﻿namespace CoPilot.Workshop.Framework
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IDictionary<string, string[]> errors)
            : base("Validation failed.")
        {
            Errors = errors;
        }
    }
}
