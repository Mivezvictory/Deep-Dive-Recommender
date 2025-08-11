namespace Deep_Dive_Recommender.Exceptions
{
    public class SpotifyCallbackExceptionException : Exception
    {
        public SpotifyCallbackExceptionException() { }
        public SpotifyCallbackExceptionException(string message) : base(message) { }
        public SpotifyCallbackExceptionException(string message, System.Exception inner) : base(message, inner) { }
    }
}
