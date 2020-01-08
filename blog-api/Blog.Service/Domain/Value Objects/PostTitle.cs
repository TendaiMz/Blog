using CSharpFunctionalExtensions;

namespace Blog.Service.Domain.ValueObjects
{
    public class PostTitle
    {
        public string Value { get; }
        private PostTitle(string title)
        {
            Value = title;
        }

        public static Result<PostTitle> Create(string postTitle)
        {
            if (string.IsNullOrEmpty(postTitle))
            {
                return Result.Failure<PostTitle>($"{nameof(postTitle)} cannot be null or empty");
            }

            if (postTitle.Length < 10)
            {
                return Result.Failure<PostTitle>($"{nameof(postTitle)} is too short");
            }

            return Result.Ok(new PostTitle(postTitle));
        }
    }
}
