using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingWebApp.Models
{
    public class Post : IModelBase
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }
        [ForeignKey(name: "UserId")]
        [Display(Name = "User")]
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        //[ignoreMember]
    }
}
