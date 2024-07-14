namespace Bookly.API.Exceptions
{
    public class ResponseModelException
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
        public int StatusCode { get; set; }
    }
}
