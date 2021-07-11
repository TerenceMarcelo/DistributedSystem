using APIClasses;
using BankDB;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataTier.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public ListStruct GetUsers()
        {
            BankDB.BankDB bank = BankDBAccess.get();
            UserAccessInterface y = bank.GetUserAccess();

            ListStruct toReturn = new ListStruct();
            toReturn.list = y.GetUsers();

            return toReturn;
        }

        [Route("api/GetUser/{userID}")]
        [HttpGet]
        public UserStruct GetUserDetails(uint userID)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            UserAccessInterface y = bank.GetUserAccess();
            y.SelectUser(userID);

            UserStruct toReturn = new UserStruct();
            toReturn.userID = userID;
            y.GetUserName(out toReturn.fName, out toReturn.lName);

            return toReturn;
        }

        [Route("api/AddUser/")]
        [HttpPost]
        public string Post([FromBody]UserStruct inUser)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            UserAccessInterface y = bank.GetUserAccess();
            uint id = y.CreateUser();
            y.SelectUser(id);
            y.SetUserName(inUser.fName, inUser.lName);
            return id.ToString();
        }
    }
}
