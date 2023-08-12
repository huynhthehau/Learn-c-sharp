namespace User.Management.API.Models
{
    
    public class Response
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public List<String> Errors { get; set; }
    }
}
