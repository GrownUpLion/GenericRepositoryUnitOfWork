using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Role : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string Name { get; set; }

        //public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            //Users = new List<User>();
        }
    }
}
