
using System.Net;

namespace IQOUTSOURCING.TransversalHelpers.ExceptionHelper
{
    public class RestException : Exception
    {
        public HttpStatusCode code { get; set; }
        public string? message { get; set; }
        public RestException(HttpStatusCode code, string? message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
