using MvcTicariOtomasyon.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Infrastructure
{
    public class OtomasyonDbContext : DbContext
    {
        public OtomasyonDbContext()
        {
            Database.Connection.ConnectionString="Server=.;Database=OtomasyonDbContext;Trusted_Connection=true;";
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceContent> InvoiceContents { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesReport> SalesReports { get; set; }
    }
}