﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AltenSonar.Core.Entities;
using AltenSonar.Models;
using AltenSonar.Infrastructure.Repos;

namespace AltenSonar.Controllers
{
    public class DashboardController : Controller
    {       
        public ActionResult Index()
        {
            var customersRepo = new FakeCustomersRepo();
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