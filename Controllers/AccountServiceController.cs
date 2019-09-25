using BrooksApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BrooksApi.Controllers
{
    [RoutePrefix("api/AccountService")]
    public class AccountServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        [Route("GetAccountDetails")]

        public async Task<BankAccount> GetAccountDetails( int accountId)
        {
            return await db.GetAccountDetails(accountId);
        }

        [Route("GetAccountDetails/json")]
        public async Task<IHttpActionResult> GetAccountAsJson(int accountId)
        {
            var data = await db.GetAccountDetails(accountId);
            return Json(data, serializerSettings);
        }

        [Route("GetHouseholdAccounts")]
        public async Task<List<BankAccount>> GetHouseholdAccounts(int houseId)
        {
            return await db.GetHouseholdAccounts(houseId);
        }

        [Route("GetHouseholdAccounts/json")]
        public async Task<IHttpActionResult> GetHouseholdAccountsAsJson(int houseId)
        {
            var data = await db.GetHouseholdAccounts(houseId);
            return Json(data, serializerSettings);
        }

        //Add account
        //Edit account
    }
}