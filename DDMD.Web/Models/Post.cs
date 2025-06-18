using System;

namespace DDMD.Web.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; } = "BrugerXYZ";
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int Likes { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
