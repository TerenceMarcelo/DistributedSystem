using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessTier.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            ViewBag.Title = "Accounts Page";
            return View();
        }
    }
}