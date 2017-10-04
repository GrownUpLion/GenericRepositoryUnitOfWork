using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string UserName { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string LastName { get; set; }
        [Required]
        public virtual string Email { get; set; }
        [Required]
        public virtual bool Active { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; } 

        public User()
        {
            Roles = new List<Role>();
        }

    }
}
