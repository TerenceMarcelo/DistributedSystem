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
    public class TransactionController : ApiController
    {
        [HttpGet]
        public ListStruct GetTransactions()
        {
            BankDB.BankDB bank = BankDBAccess.get();
            TransactionAccessInterface y = bank.GetTransactionInterface();

            ListStruct toReturn = new ListStruct();
            toReturn.list = y.GetTransactions();

            return toReturn;
        }

        [Route("api/GetTransaction/{transactionID}")]
        [HttpGet]
        public TransactionStruct GetTransactionDetails(uint transactionID)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            TransactionAccessInterface y = bank.GetTransactionInterface();
            y.SelectTransaction(transactionID);

            TransactionStruct toReturn = new TransactionStruct();
            toReturn.transactionID = transactionID;
            toReturn.destinationAccountID = y.GetRecvrAcct();
            toReturn.sourceAccountID = y.GetSendrAcct();
            toReturn.amount = y.GetAmount();
            return toReturn;
        }

        [Route("api/AddTransaction/")]
        [HttpPost]
        public string Post([FromBody] TransactionStruct inTransaction)
        {
            BankDB.BankDB bank = BankDBAccess.get();
            TransactionAccessInterface y = bank.GetTransactionInterface();
            uint id = y.CreateTransaction();
            y.SelectTransaction(id);
            y.SetAmount(inTransaction.amount);
            y.SetRecvr(inTransaction.destinationAccountID);
            y.SetSendr(inTransaction.sourceAccountID);
            return id.ToString();
        }
    }
}
