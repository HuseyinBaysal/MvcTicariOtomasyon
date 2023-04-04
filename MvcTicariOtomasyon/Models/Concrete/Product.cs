using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [StringLength(30)]
        public string ProductName { get; set; }
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool Condition { get; set; }
        [StringLength(300)]
        public string ProductImage { get; set; }



        //ilişkiler
        //Bir ürünün bir kategorisi olabilir.
        public int Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public virtual Category Category { get; set; }
        public ICollection<SalesReport> SalesReports { get; set; }
    }
}