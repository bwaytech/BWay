namespace BWay.Api.Models
{
    public class Envelope<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
