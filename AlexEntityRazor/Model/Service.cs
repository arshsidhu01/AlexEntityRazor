using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlexEntityRazor.Model
{
    public class Service
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Enter Specification")]
        public String Specification { get; set; }

        [Required(ErrorMessage = "Enter Charges")]
        public String Charges { get; set; }


    }
}
