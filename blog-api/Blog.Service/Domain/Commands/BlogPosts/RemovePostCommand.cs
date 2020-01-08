using MediatR;

namespace Blog.Service.Domain.Commands.BlogPosts
{
    public class RemovePostCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
