using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class AddQueryModel : PageModel
    {
        [BindProperty]
        public Contact contact { get; set; }

        DatabaseContext context;


        public AddQueryModel(DatabaseContext database)
        {
            context = database;
        }


        public void OnGet()
        {
        }


        public ActionResult OnPost()
        {
            var Contact = contact;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("ViewAllQuery");
            }
            contact.id = 0;
            var result = context.Add(Contact);
            context.SaveChanges();
            return RedirectToPage("ViewAllQuery");
        }
    }
}