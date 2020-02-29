using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PuntenTeller.Models
{
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }

        [Display(Name = "Category")]
        public int categoryID { get; set; }
        public Category category { get; set; }
    }
}
