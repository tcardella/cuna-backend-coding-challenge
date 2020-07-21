namespace WebAPI.Models
{
    public class PutBody
    {
        public PutBody()
        {
        }

        public PutBody(string status, string detail)
        {
            Status = status;
            Detail = detail;
        }

        public string Status { get; set; }
        public string Detail { get; set; }
    }
}