using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersAdmin.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool Active { get; set; }

        public ICollection<RoleViewModel> Roles { get; set; }

        public UserViewModel(User us)
        {
            Id = us.Id;
            FirstName = us.FirstName;
            LastName = us.LastName;
            Email = us.Email;
            Active = us.Active;
            UserName = us.UserName;
            Roles = us.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}