﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School.Web.ViewModel
{
    public class RoleCreateViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}