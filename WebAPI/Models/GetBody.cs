namespace WebAPI.Models
{
    public class GetBody
    {
        public GetBody()
        {
        }

        public GetBody(string status, string detail, string body)
        {
            Status = status;
            Detail = detail;
            Body = body;
        }

        public string Status { get; set; }
        public string Detail { get; set; }
        public string Body { get; set; }
    }
}