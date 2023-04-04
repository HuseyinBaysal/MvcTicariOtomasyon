using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [StringLength(30)]
        public string DepartmentName { get; set; }

        public bool Condition { get; set; }

        //Bir departmanda birden fazla personel bulunabilir
        public ICollection<Employee> Employees { get; set; }
    }
}