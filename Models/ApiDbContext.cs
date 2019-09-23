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
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @transactionId",
                new SqlParameter("transactionId", transactionId)).FirstOrDefaultAsync();
        }
    }
}