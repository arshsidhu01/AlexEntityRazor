using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlexEntityRazor.Model
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Enter Contact")]
        public String Contact { get; set; }


        [Required(ErrorMessage = "Enter Services")]
        public String Services { get; set; }


        [Required(ErrorMessage = "Enter Charges")]
        public String Charges { get; set; }



    }
}
