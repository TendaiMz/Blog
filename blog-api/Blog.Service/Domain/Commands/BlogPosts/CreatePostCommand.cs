using Blog.Service.Domain.Entities;
using CSharpFunctionalExtensions;
using MediatR;
using System;

namespace Blog.Service.Domain.Commands.BlogPosts
{
    public class CreatePostCommand : IRequest<Result<Post>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
