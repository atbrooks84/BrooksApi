using BrooksApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace BrooksApi.Controllers
{
    [RoutePrefix("api/TransactionService")]
    public class TransactionServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        [Route("GetTransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int transactionId)
        {
            return await db.GetTransactionDetails(transactionId);
        }

        [ResponseType(typeof(Transaction))]
        [Route("GetTransactionDetails/json")]
        public async Task<IHttpActionResult> GetTransactionDetailsAsJson(int transactionId)
        {
            var data = await db.GetTransactionDetails(transactionId);
            return Json(data, serializerSettings);
        }

        [Route("GetAccountTransactions")]
        public async Task<List<Transaction>> GetAccountTransactions(int accountId)
        {
            return await db.GetAccountTransactions(accountId);
        }

        [ResponseType(typeof(Transaction))]
        [Route("GetAccountTransactions/json")]
        public async Task<IHttpActionResult> GetAccountTransactionsAsJson(int accountId)
        {
            var data = await db.GetAccountTransactions(accountId);
            return Json(data, serializerSettings);
        }

        //Add Transaction
        [Route("AddTransaction")]
        public async Task<int> AddTransaction( string transMemo, int transType, int transBudget, int transAccount, int transAmount, string transUser)
        {
            return await db.AddTransaction(transMemo, transType, transBudget, transAccount, transAmount, transUser);
        }       

        //Delete Transaction
    }
}