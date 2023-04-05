using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [StringLength(10)]
        public string InvoiceSerialNumber { get; set; }
        [StringLength(30)]
        public string InvoiceRowNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        [StringLength(50)]
        public string TaxAdministration { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string TaxTime { get; set; }

        [StringLength(30)]
        public string Receiver { get; set; }
        [StringLength(30)]
        public string Submitter { get; set; }


        //Bir faturanın birden fazla kalemi olabilir. 

        public decimal InvoiceTotal { get; set; }
        public ICollection<InvoiceContent> InvoiceContents { get; set; }
    }
}