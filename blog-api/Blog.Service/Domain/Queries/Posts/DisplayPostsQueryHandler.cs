using Blog.Service.Domain.Entities;
using Blog.Service.Domain.Repositories;
using Blog.Service.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.Domain.Queries.Posts
{
    public class DisplayPostsQueryHandler : IRequestHandler<DisplayPostsQuery, List<BlogPostModel>>
    {
        private readonly IRepository<Post> repo;
        public DisplayPostsQueryHandler(IRepository<Post> repo)
        {
            this.repo = repo;
        }
        public async Task<List<BlogPostModel>> Handle(DisplayPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await repo.GetAll();
            return posts.Select(x => new BlogPostModel
            {
                Id = x.Id,
                Content = x.Content,
                CreationDate = x.CreationDate.Date,
                IsArchived = x.IsArchived,
                PostDate = x.CreationDate.Date,
                Title = x.Title.Value
            }).ToList();
        }
    }
}
