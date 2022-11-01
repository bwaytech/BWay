using Newtonsoft.Json;

namespace BWay.Api.Models
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {
        }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
