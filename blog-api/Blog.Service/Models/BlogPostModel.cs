using System;

namespace Blog.Service.Models
{
    public class BlogPostModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
