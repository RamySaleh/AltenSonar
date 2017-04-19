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
using AltenSonar.Infrastructure.Repos;
using AltenSonar.DependencyInjection;

namespace AltenSonar.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            var customersRepo = IocContainer.Resolve<ICustomersRepo>();
            var customers = customersRepo.GetCustomers();
            return View(customers);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

        }
    }
}
