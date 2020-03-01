using System.Collections;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Models;
using SimpleBlog.Services;

namespace SimpleBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable FindAllPost()
        {
            return _service.FindAll();
        }

        [HttpGet("/{idPost}")]
        public Post FindPost(int idPost)
        {
            return _service.Find(idPost);
        }

        [HttpPost]
        public bool Save([FromBody] Post post)
        {
            return _service.Save(post);
        }

        [HttpPut("/{idPost}")]
        public bool Update([FromBody] Post post, int idPost)
        {
            return _service.Edit(post, idPost);
        }

        [HttpDelete("/{idPost}")]
        public bool Delete(int idPost)
        {
            return _service.Remove(idPost);
        }
        
    }
}