using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrooksApi.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseholdId { get; set; }
        public DateTime Created { get; set; }
        public int Target { get; set; }
        public int Actual { get; set; }
    }
}