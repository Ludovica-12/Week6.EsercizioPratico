using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercizioPratico.Core.Interfaces;
using Week6.EsercizioPratico.Core.Models;

namespace Week6.EsercizioPratico.EF.Repositories
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext ctx;

        public EFCustomerRepository()
        {
            ctx = new CustomerContext();
        }

        public bool Add(Customer customer)
        {
            if (customer == null)
                return false;

            try
            {
                ctx.Customers.Add(new Customer
                {
                    CF = customer.CF,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                });

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceptio = " + ex.Message);
                return false;
            }
        }

        public bool Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Fetch()
        {
            try
            {
                var customers = ctx.Customers.Include(c => c.CF)
                    .ToList();
                return customers;
            }
            catch (Exception)
            {
                return new List<Customer>();
            }
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
