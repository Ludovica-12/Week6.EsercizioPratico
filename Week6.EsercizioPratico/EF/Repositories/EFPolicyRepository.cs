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
    public class EFPolicyRepository : IPolicyRepository
    {
        private readonly CustomerContext ctx;

        public EFPolicyRepository()
        {
            ctx = new CustomerContext();
        }

        public bool Add(Policy policy)
        {
            if (policy == null)
                return false;

            try
            {
                ctx.Policies.Add(new Policy
                {
                    NPolicy = policy.NPolicy,
                    Expiration = policy.Expiration,
                    MonthlyPayment = policy.MonthlyPayment,
                    Type = policy.Type

                });

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public bool Delete(Policy policy)
        {
            throw new NotImplementedException();
        }

        public List<Policy> Fetch()
        {
            try
            {
                var policies = ctx.Policies.Include(p => p.Id)
                    .ToList();

                return policies;
            }
            catch (Exception)
            {
                return new List<Policy>();
            }
        }

        public Policy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Policy policy)
        {
            throw new NotImplementedException();
        }
    }
}
