namespace Deep_Dive_Recommender.FunctionHelpers
{
    public static class FunctionHelper
    {
        public static string CombineUrl(string baseUrl, string pathOrRelative)
        {
            if (string.IsNullOrWhiteSpace(pathOrRelative)) return baseUrl;
            if (pathOrRelative.StartsWith("http", StringComparison.OrdinalIgnoreCase)) return pathOrRelative;
            if (!baseUrl.EndsWith("/")) baseUrl += "/";
            if (pathOrRelative.StartsWith("/")) pathOrRelative = pathOrRelative[1..];
            return baseUrl + pathOrRelative;
        }
    }
}