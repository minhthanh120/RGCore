﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Auth")]
    public class Auth
    {
        public int Id { get; set; }
        public string IDUser { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}