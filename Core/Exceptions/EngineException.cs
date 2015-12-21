namespace IsIs.Core.Exceptions
{
    using System;

    public class EngineException : Exception
    {
        public EngineException(string message)
            : base(message)
        {
        }
    }
}