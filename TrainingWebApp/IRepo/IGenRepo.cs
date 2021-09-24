using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Models;

namespace TrainingWebApp.IRepo
{
    public interface IGenRepo<T>  where T :  class, IModelBase
    {
        void Add (T obj);
        Task<T> Get (long id);
        Task<List<T>> GetList ();
        void Update (T obj);
        void Delete(long id);
        void Delete(T obj);
    }
}
