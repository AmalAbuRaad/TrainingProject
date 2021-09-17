using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Data;
using TrainingWebApp.IRepo;
using TrainingWebApp.Models;
using TrainingWebApp.ViewModels;

namespace TrainingWebApp.Repo
{
    public class UserRepo : GenRepo<User>, IUserRepo
    {

        public UserRepo(ApplicationDbContext context): base(context)
        {}
      
    }
}
