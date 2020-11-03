using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexEntityRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlexEntityRazor.Pages
{
    public class ViewAllServicesModel : PageModel
    {
        DatabaseContext Context;

        public ViewAllServicesModel(DatabaseContext databasecontext)
        {
            Context = databasecontext;
        }

        public List<Service> ServiceList { get; set; }


        public void OnGet()
        {

            var data = (from Servicelist in Context.services
                        select Servicelist).ToList();

            ServiceList = data;
        }


        public ActionResult OnGetDelete(int? id) {

            if (id != null)
            {
                var data = (from Service in Context.services
                            where Service.ID == id
                            select Service).SingleOrDefault();

                Context.Remove(data);
                Context.SaveChanges();
            }
            return RedirectToPage("ViewAllServices");
        }
    }
}