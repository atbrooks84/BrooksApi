using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrooksApi.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentBalance { get; set; }
        public DateTime Created { get; set; }
        public int HouseholdId { get; set; }
        public int AccountTypeId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}