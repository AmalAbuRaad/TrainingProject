using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Models;

namespace TrainingWebApp.ViewModels
{
    public class UserViewModel
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}
