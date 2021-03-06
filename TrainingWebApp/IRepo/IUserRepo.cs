using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Models;
using TrainingWebApp.ViewModels;

namespace TrainingWebApp.IRepo
{
    public interface IUserRepo: IGenRepo<User>
    {
        Task<List<User>> GetPosts();
        Task<List<ProjViewModel>> UserProj();
        Task GetRecord(int size, int number);

    }



}
