using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Data;
using TrainingWebApp.IRepo;
using TrainingWebApp.Mapper;
using TrainingWebApp.Models;
using TrainingWebApp.ViewModels;
namespace TrainingWebApp.Repo
{
    public class UserRepo : GenRepo<User>, IUserRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRepo(ApplicationDbContext context, IMapper mapper): base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<User> GetPosts()
        {
            return _context.Users.Include(u => u.Posts).ToList();
        }
        public List<ProjViewModel> UserProj()
        {
            return _context.Users.ProjectTo<ProjViewModel>(_mapper.ConfigurationProvider).ToList();


        }

    }
}
