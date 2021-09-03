using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.EsercizioPratico.Core.Interfaces;
using Week6.EsercizioPratico.Core.Models;

namespace Week6.EsercizioPratico
{
    public class MainBL
    {
        private ICustomerRepository _customerRepo;
        private IPolicyRepository _policyRepo;
        public MainBL(ICustomerRepository customerRepository, IPolicyRepository policyRepository)
        {
            _customerRepo = customerRepository;
            _policyRepo = policyRepository;
        }

        internal bool AddC(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();

            bool isAdded = _customerRepo.Add(customer);
            return isAdded;
        }

        internal List<Customer> FetchCustomers()
        {
            var custumers = _customerRepo.Fetch();
            return custumers;
        }

        internal object FetchPolicies()
        {
            var policies = _policyRepo.Fetch();
            return policies;
        }

        internal bool AddP(Policy police)
        {
            if (police == null) throw new ArgumentNullException();

            bool isAdded = _policyRepo.Add(police);
            return isAdded;
        }
    }
}
