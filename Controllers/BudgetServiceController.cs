﻿using BrooksApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BrooksApi.Controllers
{
    [RoutePrefix("api/BudgetService")]
    public class BudgetServiceController : ApiController
    {
        private ApiDbContext db = new ApiDbContext();
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };


        [Route("GetBudget")]
        public async Task<Budget> GetBudget(int budgetId)
        {
            return await db.GetBudget(budgetId);
        }

        [Route("GetBudget/json")]
        public async Task<IHttpActionResult> GetBudgetAsJson(int budgetId)
        {
            var data = await db.GetBudget(budgetId);
            return Json(data, serializerSettings);
        }

        [Route("GetHouseholdBudgets")]
        public async Task<List<Budget>> GetHouseholdBudgets(int houseId)
        {
            return await db.GetHouseholdBudgets(houseId);
        }

        [Route("GetHouseholdBudgets/json")]
        public async Task<IHttpActionResult> GetHouseholdBudgetsAsJson(int houseId)
        {
            var data = await db.GetHouseholdBudgets(houseId);
            return Json(data, serializerSettings);
        }

        [Route("AddBudget")]
        public async Task<int> AddBudget(string budgetName, int budgetTarget, int budgetActual, int budgetHousehold)
        {
            return await db.AddBudget(budgetName, budgetTarget, budgetActual, budgetHousehold);
        }

        [Route("AddAccount")]
        public async Task<int> AddAccount(string accountName, int accountBalance, int accountHouse, string accountOwner, int accountType, string accountStreet, string accountCity, string accountState)
        {
            return await db.AddAccount(accountName, accountBalance, accountHouse, accountOwner, accountType, accountStreet, accountCity, accountState);
        }

        [Route("AddTransaction")]
        public async Task<int> AddTransaction(string transMemo, int transType, int transAmount, int transBudget, int transAccount, string transUser)
        {
            return await db.AddTransaction(transMemo, transType, transAmount, transBudget, transAccount, transUser);
        }
            
    }
}