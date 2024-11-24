namespace SSCAPI.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; } 
        public string Content { get; set; }
        public string? MediaUrl { get; set; }
        public string PrivacyLevel { get; set; }
        public DateTime CreatedAt { get; set; }
	}
}