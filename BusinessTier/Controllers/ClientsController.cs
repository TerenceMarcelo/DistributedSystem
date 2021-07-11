using APIClasses;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusinessTier.Controllers
{
    public class ClientsController : ApiController
    {
        [Route("api/GetUser/{userID}")]
        [HttpGet]
        public UserStruct GetUserDetails(uint userID)
        {
            string URL = "https://localhost:44343/";
            var client = new RestClient(URL);
            RestRequest request = new RestRequest("api/getall/" + userID.ToString());
            IRestResponse resp = client.Get(request);
            UserStruct toReturn = JsonConvert.DeserializeObject<UserStruct>(resp.Content);

            return toReturn;
        }

        [Route("api/AddUser")]
        [HttpPost]
        public string AddUserDetails(string inJson)
        {
            UserStruct newUser = JsonConvert.DeserializeObject<UserStruct>(inJson);
            string URL = "https://localhost:44343/";
            var client = new RestClient(URL);
            RestRequest request = new RestRequest("api/AddUser/");
            request.AddJsonBody(newUser);
            client.Post(request);
            request = new RestRequest("api/Save");
            IRestResponse resp = client.Post(request);
            return resp.Content;
        }

        [Route("api/GetTransaction/{transactionID}")]
        [HttpGet]
        public TransactionStruct GetTransaction(uint transactionID)
        {
            string URL = "https://localhost:44343/";
            var client = new RestClient(URL);
            RestRequest request = new RestRequest("api/GetTransaction/" + transactionID.ToString());
            IRestResponse resp = client.Get(request);
            TransactionStruct toReturn = JsonConvert.DeserializeObject<TransactionStruct>(resp.Content);

            return toReturn;
        }

        [Route("api/AddTransaction")]
        [HttpPost]
        public string AddTransaction(string inJson)
        {
            UserStruct newTransaction = JsonConvert.DeserializeObject<UserStruct>(inJson);
            string URL = "https://localhost:44343/";
            var client = new RestClient(URL);
            RestRequest request = new RestRequest("api/AddTransaction/");
            request.AddJsonBody(newTransaction);
            IRestResponse resp = client.Post(request);
            request = new RestRequest("api/ProcessTransactions");
            client.Post(request);
            request = new RestRequest("api/Save");
            client.Post(request);
            return resp.Content;
        }

        [Route("api/AddAccount")]
        [HttpPost]
        public string AddAccount(string inJson)
        {
            AccountStruct newTransaction = JsonConvert.DeserializeObject<AccountStruct>(inJson);
            string URL = "https://localhost:44343/";
            var client = new RestClient(URL);
            RestRequest request = new RestRequest("api/AddAccount/");
            request.AddJsonBody(newTransaction);
            client.Post(request);
            request = new RestRequest("api/Save");
            IRestResponse resp = client.Post(request);
            return resp.Content;
        }

        [Route("api/GetAccount/{accountID}")]
        [HttpGet]
        public TransactionStruct GetAccount(uint accountID)
        {
            string URL = "https://localhost:44343/";
            var client = new RestClient(URL);
            RestRequest request = new RestRequest("api/GetTransaction/" + accountID.ToString());
            IRestResponse resp = client.Get(request);
            TransactionStruct toReturn = JsonConvert.DeserializeObject<TransactionStruct>(resp.Content);

            return toReturn;
        }
    }
}
