using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessTier.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            ViewBag.Title = "Transactions Page";
            return View();
        }
    }
}