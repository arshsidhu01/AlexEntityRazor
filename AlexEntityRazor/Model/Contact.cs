using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlexEntityRazor.Model
{
    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Enter Message")]
        public String Message { get; set; }

    }
}
