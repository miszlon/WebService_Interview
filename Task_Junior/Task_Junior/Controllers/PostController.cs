using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeBlog.Api.ViewModels;
using AwesomeBlog.Infrastructure;
using AwesomeBlog.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeBlog.Api.Controllers
{
    [Route("[controller]")]
    public class PostController : ControllerBase
    {

        public readonly BlogRepository _blogRepository;
        public PostController(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        [HttpPost("{blogId:guid}")]
        public async Task<IActionResult> AddPost(Guid blogId, [FromBody] CreatePostViewModel createPostViewModel)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _blogRepository.AddPost(blogId, new Post
                 (
                     createPostViewModel.Id,
                     createPostViewModel.Title,
                     createPostViewModel.Content,
                     createPostViewModel.CreatedOn
                  ));

            return Ok();
        }

    }
}
