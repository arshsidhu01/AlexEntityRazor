using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class EditQueryModel : PageModel
    {
        DatabaseContext Context;
        public EditQueryModel(DatabaseContext databasecontext)
        {
            Context = databasecontext;
        }

        [BindProperty]
        public Contact Contact { get; set; }


        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from Contact in Context.Contact
                            where Contact.id == id
                            select Contact).SingleOrDefault();

                Contact = data;
            }

        }



        public ActionResult OnPost()
        {
            var contact = Contact;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("ViewAllQuery");
            }

            Context.Entry(contact).Property(x => x.Name).IsModified = true;
            Context.Entry(contact).Property(x => x.Email).IsModified = true;
            Context.Entry(contact).Property(x => x.Message).IsModified = true;
            Context.SaveChanges();
            return RedirectToPage("ViewAllQuery");
        }

    }
}