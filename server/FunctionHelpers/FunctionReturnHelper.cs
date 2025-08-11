using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Deep_Dive_Recommender.FunctionHelpers
{
    public static class FunctionReturnHelpers
    {
        public static ActionResult CreateReturnResponse(String returnObj, string statusCode)
        {
            return new ContentResult
            {
                Content = returnObj,
                ContentType = "application/json",
                StatusCode = GetStatusCode(statusCode)
            };
        }

        private static int GetStatusCode(String statusCode)
        {
            return statusCode.ToLower() switch
            {
                "ok" => (int)HttpStatusCode.OK,
                "badrequest" => (int)HttpStatusCode.BadRequest,
                "notfound" => (int)HttpStatusCode.NotFound,
                "redirect" => (int)HttpStatusCode.Redirect,
                "internalservererror" => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}