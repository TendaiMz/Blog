using Blog.Service.Domain.Entities;
using Blog.Service.Domain.Repositories;
using Blog.Service.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Service.Domain.Commands.BlogPosts
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Result<Post>>
    {
        private readonly IRepository<Post> repo;
        public CreatePostCommandHandler(IRepository<Post> repo)
        {
            this.repo = repo;
        }
        public async Task<Result<Post>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Result<PostTitle> postTitleOrError = PostTitle.Create(request.Title);
            if (postTitleOrError.IsFailure)
            {
                return Result.Failure<Post>(postTitleOrError.Error);
            }          

            var post = new Post(postTitleOrError.Value, request.CreationDate, request.Content);
            await repo.Save(post);
            var pst = await repo.GetAll();
            return Result.Ok(pst.LastOrDefault());

        }
    }
}
