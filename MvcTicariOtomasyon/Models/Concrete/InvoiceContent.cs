using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class InvoiceContent
    {
        [Key]
        public int InvoiceContentID { get; set; }
        [StringLength(300)]
        public string InvoiceDescription { get; set; }
        [StringLength(30)]
        public string InvoiceAmount { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        //Bir kalem bir faturada bulunabilir.

        public int Invoiceid { get; set; }
        [ForeignKey("Invoiceid")]
        public virtual Invoice Invoice { get; set; }
    }
}