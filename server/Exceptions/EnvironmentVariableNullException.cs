namespace Deep_Dive_Recommender.Exceptions
{
    /*
    * Exception to be thrown when environment variable values are not provided
    */
    public class EnvironmentVariableNullException : Exception
    {
        public EnvironmentVariableNullException() { }
        public EnvironmentVariableNullException(string message) : base(message) { }
        public EnvironmentVariableNullException(string message, System.Exception inner) : base(message, inner) { }
    }
}
