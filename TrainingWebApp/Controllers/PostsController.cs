using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingWebApp.Data;
using TrainingWebApp.IRepo;
using TrainingWebApp.Models;
using TrainingWebApp.ViewModels;

namespace TrainingWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepo _repository;
        private readonly IMapper _mapper;

        public PostsController(IPostRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Posts
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<PostViewModel>> GetPosts()
        {
            var posts = await _repository.GetList();
            return _mapper.Map<List<PostViewModel>>(posts);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<PostViewModel> GetPost(long id)
        {
            var user = await _repository.Get(id);
            return _mapper.Map<PostViewModel>(user);
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutPost(long id, [FromBody] PostViewModel postVM)
        {
            var post = _mapper.Map<PostViewModel, Post>(postVM);
            _repository.Update(post);
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostPost([FromBody] PostViewModel postVM)
        {
            var post = _mapper.Map<PostViewModel, Post>(postVM);
            _repository.Add(post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public void DeleteById(long id)
        {
            _repository.Delete(id);
        }

        /*[HttpDelete("DeleteByPost/{post}")]
        public void DeleteByPost([FromBody] PostViewModel postVM)
        {
            var post = _mapper.Map<Post>(postVM);
            _repository.Delete(post);
        }*/
    }
}
