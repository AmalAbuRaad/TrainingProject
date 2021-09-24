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
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IMapper _mapper;
        public UserRepo(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper) : base(contextFactory)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }
        public async Task<List<User>> GetPosts()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.Users.Include(u => u.Posts).ToListAsync();
            }
        }
        public async Task<List<ProjViewModel>> UserProj()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.Users.ProjectTo<ProjViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            }


        }
        public async Task GetRecord(int size, int number)
        {
            
            using (var _context = _contextFactory.CreateDbContext())
            {
                var x = _context.Users.OrderBy(u => u.Id)
                                  .Skip(size * (number - 1))
                                  .Take(size)
                                  .ToListAsync();
                using (var _context1 = _contextFactory.CreateDbContext())
                {
                  var y = _context1.Users.CountAsync();

                    await Task.WhenAll(new List<Task>() { x ,y});

                }
            }
       
            


        }

    }
}
