using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Data;
using TrainingWebApp.IRepo;
using TrainingWebApp.Models;

namespace TrainingWebApp.Repo
{
    public class GenRepo<T> : IGenRepo<T> where T : class, IModelBase
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        public GenRepo(IDbContextFactory<ApplicationDbContext> contextFactory) 
        {
            _contextFactory = contextFactory;
        }

        public async void Add(T obj)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async void Delete(long id)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                var obj = await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async void Delete(T obj)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                _context.Set<T>().Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> Get(long id)
        {
            using (var _context = _contextFactory.CreateDbContext()) { 
                return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id);
        }
        }

        public async Task<List<T>> GetList()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.Set<T>().ToListAsync();
            }
        }

        public async void Update(T obj)
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                _context.Set<T>().Update(obj);
                await _context.SaveChangesAsync();
            }
        }
    }
}
