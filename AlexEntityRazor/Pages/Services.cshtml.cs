using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class ServicesModel : PageModel
    {
        [BindProperty]

        public Service service { get; set; }
        DatabaseContext context;


        public ServicesModel(DatabaseContext database) {
            context = database;
        }


        public void OnGet()
        {
            
        }
        
        public ActionResult OnPost() {
            var services = service;
            if (!ModelState.IsValid) {
                return RedirectToPage("ViewAllServices");
            }
            service.ID = 0;
            var result = context.Add(services);
            context.SaveChanges();
            return RedirectToPage("ViewAllServices");
        }
    }
}