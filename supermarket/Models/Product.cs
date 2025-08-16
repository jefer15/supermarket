using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace supermarket.Models
{
    [Index("Code", Name = "UQ__Products__A25C5AA761FA359B", IsUnique = true)]
    public partial class Product
    {
        public Product()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Display(Name = "Código")]
        public string Code { get; set; } = null!;

        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Precio Unitario")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Cantidad en Stock")]
        public int StockQuantity { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
