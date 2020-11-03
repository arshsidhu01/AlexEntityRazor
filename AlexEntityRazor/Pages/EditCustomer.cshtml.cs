using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class EditCustomerModel : PageModel
    {
        DatabaseContext Context;
        public EditCustomerModel(DatabaseContext databasecontext)
        {
            Context = databasecontext;
        }

        [BindProperty]
        public Customer Customer{ get; set; }


        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from Customer in Context.Customer
                            where Customer.ID == id
                            select Customer).SingleOrDefault();

                Customer = data;
            }

        }



        public ActionResult OnPost()
        {
            var customer = Customer;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("ViewAllCustomer");
            }

            Context.Entry(customer).Property(x => x.Name).IsModified = true;
            Context.Entry(customer).Property(x => x.Address).IsModified = true;
            Context.Entry(customer).Property(x => x.Contact).IsModified = true;
            Context.Entry(customer).Property(x => x.Services).IsModified = true;
            Context.Entry(customer).Property(x => x.Charges).IsModified = true;
            Context.SaveChanges();
            return RedirectToPage("ViewAllCustomer");
        }

    }
}