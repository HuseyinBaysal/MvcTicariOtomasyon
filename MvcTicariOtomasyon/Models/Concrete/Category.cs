using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //İlişki Bağlantıları
        //Ürün ve kategori arasında bire çok ilişki kurulur.
        //Bir ürün bir kategoride bulunabilir ama bir kategori'de birden fazla ürün bulunabilir. 

        //her kategori içinde birden fazla ürün bulunabilir.

        //Kategori birden fazla ürünleri bir arada tıtabilmek için değişken olarak ICollection kullanılır. <Type> içerisinde birden fazla tutulacak class verilir.

        public ICollection<Product> Products { get; set; }
    }
}