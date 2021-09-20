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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<UserViewModel> GetUsers()
        {
            var users =  _repository.GetList();
            return _mapper.Map<List<UserViewModel>>(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public UserViewModel GetUser(long id)
        {
            var user = _repository.Get(id);
            return _mapper.Map<UserViewModel>(user);

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutUser(long id, [FromBody] UserViewModel userVM)
        {
            var user = _mapper.Map<UserViewModel, User>(userVM);
            _repository.Update(user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostUser([FromBody] UserViewModel userVM)
        {
            var user = _mapper.Map<UserViewModel, User> (userVM);
            _repository.Add(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public void DeleteUser(long id)
        {
           _repository.Delete(id);
        }

        [HttpGet("GetPosts")]
        public IEnumerable<UserViewModel> GetUserPosts()
        {
            var posts = _repository.GetPosts();
            return _mapper.Map<List<UserViewModel>>(posts);

        }

        [HttpGet("GetFullName")]
        public IEnumerable<ProjViewModel> GetFN()
        {
            return _repository.UserProj();


        }

        /*[HttpDelete("DeleteByUser/{user}")]
        public void DeleteUser(UserViewModel userVM)
        {
            var user = _mapper.Map<User>(userVM);
            _repository.Delete(user);
        }*/
    }
}
