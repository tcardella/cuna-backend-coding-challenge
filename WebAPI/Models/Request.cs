namespace WebAPI.Models
{
    public class Request
    {
        public Request()
        {
        }

        public Request(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public string PartitionKey { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string Body { get; set; }
    }
}