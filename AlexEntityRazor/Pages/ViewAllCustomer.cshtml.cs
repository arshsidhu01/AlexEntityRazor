using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class ViewAllCustomerModel : PageModel
    {
        DatabaseContext Context;

        public ViewAllCustomerModel(DatabaseContext databasecontext)
        {
            Context = databasecontext;
        }

        public List<Customer> CustomerList { get; set; }

        public void OnGet()
        {
            var data = (from Customerlist in Context.Customer
                        select Customerlist).ToList();

            CustomerList = data;

        }


        public ActionResult OnGetDelete(int? id)
        {

            if (id != null)
            {
                var data = (from Customer in Context.Customer
                            where Customer.ID == id
                            select Customer).SingleOrDefault();

                Context.Remove(data);
                Context.SaveChanges();
            }
            return RedirectToPage("ViewAllCustomer");
        }

    }
}