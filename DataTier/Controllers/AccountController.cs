using APIClasses;
using BankDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataTier.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/Account/{accountID}")]
        [HttpGet]
        public AccountStruct GetAccountDetails(uint accountID)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            AccountAccessInterface account = bank.GetAccountInterface();
            account.SelectAccount(accountID);

            AccountStruct toReturn = new AccountStruct();
            toReturn.accountID = accountID;
            toReturn.balance = account.GetBalance();
            toReturn.userID = account.GetOwner();

            return toReturn;
        }

        [Route("api/AccountList/{userID}")]
        [HttpGet]
        public ListStruct GetAccountList(uint userID)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            AccountAccessInterface y = bank.GetAccountInterface();
            ListStruct toReturn = new ListStruct();
            toReturn.list = y.GetAccountIDsByUser(userID);

            return toReturn;
        }

        [Route("api/AddAccount/")]
        [HttpPost]
        public string Post([FromBody]AccountStruct inAccount)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            AccountAccessInterface y = bank.GetAccountInterface();
            uint AccountID = y.CreateAccount(inAccount.userID);
            y.SelectAccount(AccountID);
            y.Deposit(inAccount.balance);
            return AccountID.ToString();
        }
    }
}
