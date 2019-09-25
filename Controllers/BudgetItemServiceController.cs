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
    [RoutePrefix("api/BudgetItemService")]
    public class BudgetItemServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        [Route("GetBudgetItemDetails")]
        public async Task<BudgetItem> GetBudgetItemDetails(int budgetitemId)
        {
            return await db.GetBudgetItemDetails(budgetitemId);
        }

        [Route("GetBudgetItemDetails/json")]
        public async Task<IHttpActionResult> GetBudgetItemDetailsAsJson (int budgetitemId)
        {
            var data = await db.GetBudgetItemDetails(budgetitemId);
            return Json(data, serializerSettings);
        }

        [Route("GetBudgetItems")]
        public async Task<List<BudgetItem>> GetBudgetItems (int budgetId)
        {
            return await db.GetBudgetItems(budgetId);
        }

        [Route("GetBudgetItems/json")]
        public async Task<IHttpActionResult> GetBudgetItemsAsJson(int budgetId)
        {
            var data = await db.GetBudgetItems(budgetId);
            return Json(data, serializerSettings);
        }

        //Add budget
        //Edit budget
    }
}