﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public ICollection<Subject> subjects { get; set; }
    }
}
