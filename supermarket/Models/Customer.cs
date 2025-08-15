using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace supermarket.Models
{
    [Index("IdentificationNumber", Name = "UQ__Customer__9CD14694D1098FE6", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string IdentificationNumber { get; set; } = null!;
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string? Address { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
