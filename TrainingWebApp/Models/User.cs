using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingWebApp.Models
{
    public class User : IModelBase
    {
        public User()
        {
            this.CreateDate = DateTime.Now;

        }
        [Key]
        [Required]
        public long Id { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Age { get; set; }
        public ICollection<Post> Posts { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
