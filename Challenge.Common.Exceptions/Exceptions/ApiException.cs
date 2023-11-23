using System.Net;

namespace Challenge.Common.Exceptions.Exceptions
{
    public class ApiException : Exception
    {
        public string _message { get; }
        public object _request { get; }
        public HttpStatusCode _statusCode { get; }

        public ApiException(int statusCode, string message)
        {
            _statusCode = (HttpStatusCode)statusCode;
            _message = message;
        }

        public ApiException(HttpStatusCode statusCode, string message, object request)
           : base(message)
        {
            _statusCode = statusCode;
            _message = message;
            _request = request;
        }
    }
}
