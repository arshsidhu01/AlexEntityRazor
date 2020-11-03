using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class ViewAllQueryModel : PageModel
    {
        DatabaseContext Context;

        public ViewAllQueryModel(DatabaseContext databasecontext)
        {
            Context = databasecontext;
        }

        public List<Contact> ContactList { get; set; }

        public void OnGet()
        {
            var data = (from Contactlist in Context.Contact
                        select Contactlist).ToList();

            ContactList = data;

        }


        public ActionResult OnGetDelete(int? id)
        {

            if (id != null)
            {
                var data = (from Contact in Context.Contact
                            where Contact.id == id
                            select Contact).SingleOrDefault();

                Context.Remove(data);
                Context.SaveChanges();
            }
            return RedirectToPage("ViewAllQuery");
        }

    }
}