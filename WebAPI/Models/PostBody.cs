namespace WebAPI.Models
{
    public class PostBody
    {
        public PostBody(string body)
        {
            Body = body;
        }

        public string Body { get; set; }
    }
}