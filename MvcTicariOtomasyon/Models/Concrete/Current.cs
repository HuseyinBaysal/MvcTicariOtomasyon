using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }
        [StringLength(30, ErrorMessage = "En Fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string CurrentFirstName { get; set; }
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string CurrentLastName { get; set; }
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter Yazabilirsiniz.")]
        public string CurrentCity { get; set; }
        [StringLength(50)]
        public string CurrentMail { get; set; }
        public bool Condition { get; set; }

        //ilişki

        public ICollection<SalesReport> SalesReports { get; set; }
    }
}