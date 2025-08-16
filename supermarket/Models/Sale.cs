using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace supermarket.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Fecha de Venta")]
        public DateTime SaleDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Monto Total")]
        public decimal TotalAmount { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Sales")]
        public virtual Customer Customer { get; set; } = null!;
        
        [InverseProperty("Sale")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
