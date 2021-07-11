using APIClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataTier.Controllers
{
    public class AdminController : ApiController
    {
        [Route("api/ProcessTransactions")]
        [HttpPost]
        public void ProcessTransactions()
        {
            BankDB.BankDB bank = BankDBAccess.get();
            bank.ProcessAllTransactions();
        }

        [Route("api/Save")]
        [HttpPost]
        public void Save()
        {
            BankDB.BankDB bank = BankDBAccess.get();
            bank.SaveToDisk();
        }
    }
}
