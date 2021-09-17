using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingWebApp.Models
{
    public class User : IModelBase
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public ICollection<Post> Posts { get; set; }
        //public DateTime CreateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
