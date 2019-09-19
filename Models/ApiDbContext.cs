using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BrooksApi.Models
{
    
    public class ApiDbContext : DbContext
    {
        public ApiDbContext()
            : base("DefaultConnection")
        {

        }
    }
}