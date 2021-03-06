﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdApi.Models
{
    public class UserPermissionRoles
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoleDescription { get; set; }

        public ICollection<Permissions> Permissions { get; set; }
    }
}