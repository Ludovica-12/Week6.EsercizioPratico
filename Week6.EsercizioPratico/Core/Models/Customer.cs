using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.EsercizioPratico.Core.Models
{
    public class Customer
    {
        public Customer()
        {
            Policies = new List<Policy>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16), MinLength(16)]
        public string CF { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        
        public virtual ICollection<Policy> Policies { get; set; }


        
    }
}
