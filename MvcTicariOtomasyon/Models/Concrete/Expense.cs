using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }
        [StringLength(300)]
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal ExpensePrice { get; set; }
    }
}