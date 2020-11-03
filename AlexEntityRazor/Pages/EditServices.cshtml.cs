using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class EditServicesModel : PageModel
    {
        DatabaseContext Context;
        public EditServicesModel(DatabaseContext databasecontext)
        {
            Context = databasecontext;
        }

        [BindProperty]
        public Service service { get; set; }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var data = (from Service in Context.services
                            where Service.ID == id
                            select Service).SingleOrDefault();

                service = data;
            }
                
        }


        public ActionResult OnPost()
        {
            var Service = service;
            if (!ModelState.IsValid)
            {
                return RedirectToPage("ViewAllServices");
            }

            Context.Entry(Service).Property(x => x.Name).IsModified = true;
            Context.Entry(Service).Property(x => x.Specification).IsModified = true;
            Context.Entry(Service).Property(x => x.Charges).IsModified = true;
            Context.SaveChanges();
            return RedirectToPage("ViewAllServices");
        }

    }
}