using BrooksApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace BrooksApi.Controllers
{
    [RoutePrefix("api/HouseholdService")]
    public class HouseholdServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
        //Get all households

        [Route("GetHouseholds")]
        public async Task<List<Household>> GetHouseholds()
        {
            return await db.GetAllHouseholds();
        }

        [Route("GetAllHouseholds/json")]
        public async Task<IHttpActionResult> GetAllHouseholdsAsJson()
        {            
            var data = await db.GetAllHouseholds();
            return Json(data, serializerSettings);
        }

        //Get specific household
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int id)
        {
            return await db.GetHousehold(id);
        }

        [Route("GetHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdAsJson(int id)
        {
            var data = await db.GetHousehold(id);
            return Json(data, serializerSettings);
        }
    }
}