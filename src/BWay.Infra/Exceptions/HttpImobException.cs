using System.Net;

namespace BWay.Infra.Exceptions
{
    public class HttpImobException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpImobException(HttpStatusCode status, string msg) : base(msg)
        {
            StatusCode = status;
        }
    }
}
