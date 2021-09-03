using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercizioPratico.Core.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }
        public int NPolicy { get; set; }
        public DateTime Expiration { get; set; }
        public decimal MonthlyPayment { get; set; }
        public TypeEnum Type { get; set; }

        public int CoustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
    
    public enum TypeEnum
    {
        RCAuto = 1,
        Theft = 2,
        Life = 3
    }

}
