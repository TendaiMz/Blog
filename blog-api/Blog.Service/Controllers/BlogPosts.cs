using Blog.Service.Domain.Commands.BlogPosts;
using Blog.Service.Domain.Queries.Posts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : BaseController
    {
        private readonly IMediator mediator;
        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new DisplayPostsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post()//[FromBody] BlogPostDto)
        {
            var command = new CreatePostCommand()
            {
                Title = "The",
                Content = "Great Content",
                CreationDate = DateTime.Now
            };

            var result = await mediator.Send(command);
            if (result.IsFailure) { 
            
              return  BadRequest(result.Error);
            }
            return Ok();
          // return result.IsSuccess? Ok() : BadRequest(result.Error);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
