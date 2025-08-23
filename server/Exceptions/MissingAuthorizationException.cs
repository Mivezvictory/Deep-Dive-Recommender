namespace Deep_Dive_Recommender.Exceptions
{
    public class MissingAuthorizationException : Exception
    {
        public MissingAuthorizationException() { }
        public MissingAuthorizationException(string message) : base(message) { }
        public MissingAuthorizationException(string message, System.Exception inner) : base(message, inner) { }
    }
}
