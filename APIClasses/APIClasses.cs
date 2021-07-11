using BankDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIClasses
{
    public class APIClasses
    {
    }

    public class AccountStruct
    {
        public uint accountID;
        public uint userID;
        public uint balance;
    }

    public class UserStruct
    {
        public uint userID;
        public string fName;
        public string lName;
    }

    public class ListStruct
    {
        public List<uint> list;
    }

    public class TransactionStruct
    {
        public uint transactionID;
        public uint sourceAccountID;
        public uint destinationAccountID;
        public uint amount;
    }

    public static class BankDBAccess
    {
        private static BankDB.BankDB bankDB;

        public static BankDB.BankDB get()
        {
            if(bankDB == null)
            {
                bankDB = new BankDB.BankDB();
            }

            return bankDB;
        }
    }
}
