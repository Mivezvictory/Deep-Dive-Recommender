namespace Deep_Dive_Recommender.Exceptions
{
    public class EnvironmentVariableNullException : Exception
    {
        public EnvironmentVariableNullException() { }
        public EnvironmentVariableNullException(string message) : base(message) { }
        public EnvironmentVariableNullException(string message, System.Exception inner) : base(message, inner) { }
    }
}
