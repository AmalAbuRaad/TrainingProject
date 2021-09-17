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
        private readonly ApplicationDbContext _context;
        public GenRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var obj = _context.Set<T>().FirstOrDefault(t => t.Id == id);
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }
    }
}
