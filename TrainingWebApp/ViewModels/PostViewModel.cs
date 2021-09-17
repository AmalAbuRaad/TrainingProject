using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Models;

namespace TrainingWebApp.ViewModels
{
    public class PostViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }

    }
}
