using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class SalesReport
    {
        [Key]
        public int SalesReportID { get; set; }
        //ürün      produckt
        //cari      current
        //personel  employee
        public DateTime SalesDate { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        //Satış Hareket içinde ürün,cari ve personel ilişkisi verilir.
        public int Productid { get; set; }
        [ForeignKey("Productid")]
        public virtual Product Product { get; set; }
        public int Currentid { get; set; }
        [ForeignKey("Currentid")]
        public virtual Current Current { get; set; }
        public int Employeeid { get; set; }
        [ForeignKey("Employeeid")]
        public virtual Employee Employee { get; set; }
    }
}