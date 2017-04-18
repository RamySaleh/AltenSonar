using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AltenSonar.Core.Entities;
using AltenSonar.Core.Interfaces;
using AltenSonar.Models;
using AltenSonar.Infrastructure.Repos;
using AltenSonar.DependencyInjection;
using Autofac;

namespace AltenSonar.Controllers
{
    public class DashboardController : Controller
    {       
        public ActionResult Index()
        {
            var customersRepo = AutoFacDependencyResolver.IocContainer.Resolve<ICustomersRepo>();                       

            return View(customersRepo.GetCustomers());
        }     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
            base.Dispose(disposing);
        }
    }
}
