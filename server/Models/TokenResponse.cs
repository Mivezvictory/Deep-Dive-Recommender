namespace Deep_Dive_Recommender.Models
{
    public sealed class TokenResponse
        {
            public string? AccessToken { get; set; }      // access_token
            public string? TokenType { get; set; }        // token_type
            public int ExpiresIn { get; set; }           // expires_in (seconds)
            public string? RefreshToken { get; set; }     // refresh_token
            public string? Scope { get; set; }            // scope
        }
}