using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class AddCustomerModel : PageModel
    {
        [BindProperty]
        public Customer customer { get; set; }

        DatabaseContext context;


        public AddCustomerModel(DatabaseContext database)
        {
            context = database;
        }

        public void OnGet()
        {

        }


        public ActionResult OnPost()
        {
            var Customer = customer;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("ViewAllCustomer");
            }
            customer.ID = 0;
            var result = context.Add(customer);
            context.SaveChanges();
            return RedirectToPage("ViewAllCustomer");
        }
    }
}