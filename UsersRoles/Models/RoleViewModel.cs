﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsersAdmin.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}