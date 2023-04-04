using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [StringLength(30)]
        public string EmployeeFirstName { get; set; }
        [StringLength(30)]
        public string EmployeeLastName { get; set; }
        [StringLength(300)]
        public string EmployeeImage { get; set; }

        //ilişki
        public int Departmentid { get; set; }
        [ForeignKey("Departmentid")]
        public virtual Department Department { get; set; }

        public ICollection<SalesReport> SalesReports { get; set; }
    }
}