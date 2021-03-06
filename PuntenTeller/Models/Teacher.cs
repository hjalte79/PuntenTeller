﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PuntenTeller.Models
{
    public class Teacher
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lastName { get; set; }

        public string fullName
        {
            get
            {
                return string.Format("{0} {1}", name, lastName);
            }
        }
    }
}
