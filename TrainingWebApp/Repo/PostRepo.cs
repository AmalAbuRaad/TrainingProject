using Microsoft.AspNetCore.Mvc;
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
    public class PostRepo: GenRepo<Post>, IPostRepo
    {
        public PostRepo(ApplicationDbContext context) : base(context)
        {}


}
}
