using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BrooksApi.Models
{
    
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
            : base("LivePortalApi")
        {

        }

        public static ApiDbContext Create()
        {
            return new ApiDbContext();
        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Budget> Budgets { get; set; }

        public DbSet<Household> Households { get; set; }

        public DbSet <BudgetItem> BudgetItems { get; set; }

        public DbSet <Transaction> Transactions { get; set; }



        public async Task<List<Household>> GetAllHouseholds()
        {
            return await Database.SqlQuery<Household>("GetAllHouseholds").ToListAsync();
        }

        public async Task<Household> GetHousehold(int houseId)
        {
            return await Database.SqlQuery<Household>("GetHousehold @houseId",
                new SqlParameter("houseId", houseId)).FirstOrDefaultAsync();
        }

        public async Task<Budget> GetBudget(int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudget @budgetId",
                new SqlParameter("budgetId", budgetId)).FirstOrDefaultAsync();
        }

        public async Task<List<Budget>> GetHouseholdBudgets(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetHouseholdBudgets @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        public async Task<List<BankAccount>> GetHouseholdAccounts(int houseId)
        {
            return await Database.SqlQuery<BankAccount>("GetHouseholdAccounts @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        public async Task<BankAccount> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<BankAccount>("GetAccountDetails @accountId",
                new SqlParameter("accountId", accountId)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetAccountTransactions(int accountId)
        {
            return await Database.SqlQuery<Transaction>("GetAccountTransactions @accountId",
                new SqlParameter("accountId", accountId)).ToListAsync();
        }

        public async Task<BudgetItem> GetBudgetItemDetails(int budgetitemId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @budgetitemId",
                new SqlParameter("budgetitemId", budgetitemId)).FirstOrDefaultAsync();
        }

        public async Task<List<BudgetItem>> GetBudgetItems (int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }

        public async Task<Transaction> GetTransactionDetails(int transactionId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @tranHouse @description, @startingBalance, @currentBalancesactionId",
                new SqlParameter("transactionId", transactionId)).FirstOrDefaultAsync();
        }

        public async Task<int> AddTransaction(string transMemo, int transType, int transAmount, int transBudget, int transAccount, string transUser)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @transMemo, @transType, @transAmount, @transBudget, @transAccount, @transUser",
               new SqlParameter("@transMemo", transMemo),
               new SqlParameter("@transType", transType),
               new SqlParameter("@transAmount", transAmount),
               new SqlParameter("@transBudget", transBudget),
               new SqlParameter("@transAccount", transAccount),
               new SqlParameter("@transUser", transUser)
                );
        }

        public async Task<int> AddAccount(string accountName, int accountBalance, int accountHouse, string accountOwner, int accountType, string accountStreet, string accountCity, string accountState)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @accountName, @accountBalance, @accountHouse, @accountOwner, @accountType, @accountStreet, @accountCity, @accountState",
                new SqlParameter("@accountName", accountName),
                new SqlParameter("@accountBalance", accountBalance),
                new SqlParameter("@accountHouse", accountHouse),
                new SqlParameter("@accountOwner", accountOwner),
                new SqlParameter("@accountType", accountType),
                new SqlParameter("@accountStreet", accountStreet),
                new SqlParameter("@accountCity", accountCity),
                new SqlParameter("@accountState", accountState)
                );
        }

        public async Task<int> AddBudget(string budgetName, int budgetTarget, int budgetActual, int budgetHousehold)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @budgetName, @budgetTarget, @budgetActual, @budgetHousehold",
                new SqlParameter("@budgetName", budgetName),
                new SqlParameter("@budgetTarget", budgetTarget),
                new SqlParameter("@budgetActual", budgetActual),
                new SqlParameter("@budgetHousehold", budgetHousehold)
                );
        }       
        
    }
}