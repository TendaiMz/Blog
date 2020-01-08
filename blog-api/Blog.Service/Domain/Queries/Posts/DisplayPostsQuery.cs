using Blog.Service.Domain.Entities;
using Blog.Service.Models;
using MediatR;
using System.Collections.Generic;

namespace Blog.Service.Domain.Queries.Posts
{
    public class DisplayPostsQuery : IRequest<List<BlogPostModel>>
    {

    }

}
