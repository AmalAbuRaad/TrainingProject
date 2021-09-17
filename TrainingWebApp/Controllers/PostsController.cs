using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingWebApp.Data;
using TrainingWebApp.IRepo;
using TrainingWebApp.Models;

namespace TrainingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepo _repository;

        public PostsController(IPostRepo repository)
        {
            _repository = repository;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _repository.GetList();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public Post GetPost(long id)
        {
            return _repository.Get(id);
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutPost(long id, Post post)
        {
            _repository.Update(post);
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostPost(Post post)
        {
            _repository.Add(post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("DeleteById/{id}")]
        public void DeleteById(long id)
        {
            _repository.Delete(id);
        }

        [HttpDelete("DeleteByPost/{post}")]
        public void DeleteByPost(Post post)
        {
            _repository.Delete(post);
        }
    }
}
