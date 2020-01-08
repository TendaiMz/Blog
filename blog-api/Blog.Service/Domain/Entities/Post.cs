using Blog.Service.Domain.ValueObjects;
using System;

namespace Blog.Service.Domain.Entities
{
    public class Post : Entity
    {

        public Post(PostTitle posttitle, DateTime? dateOfCreation, string content)
        {
            Title=posttitle ?? throw new ArgumentNullException(nameof(posttitle));         
            CreationDate = dateOfCreation ?? throw new ArgumentNullException(nameof(content));
            Content = content ?? throw new ArgumentNullException(nameof(content)); ;

        }

        public PostTitle Title { get; }
        public string Content { get; }
        public DateTime? ArchiveDate { get; private set; }
        public bool IsArchived { get; private set; }

        public void ArchivePost()
        {
            if (this.IsArchived)
            {
                throw new Exception($"{nameof(Title)} Has been archived already");
            }

            this.IsArchived = true;
            this.ArchiveDate = DateTime.Now;


        }
    }
}
