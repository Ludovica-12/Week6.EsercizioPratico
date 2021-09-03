using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercizioPratico.Core.Models;

namespace Week6.EsercizioPratico.EF
{
    public class CustomerContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
		                                Database=InsurancePolicy;Trusted_Connection=True;");
        }
    }
}
