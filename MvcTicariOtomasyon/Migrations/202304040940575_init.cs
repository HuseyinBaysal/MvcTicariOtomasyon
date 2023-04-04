namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 30),
                        Password = c.String(maxLength: 30),
                        Authority = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 30),
                        Marka = c.String(maxLength: 30),
                        Stok = c.Short(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Condition = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 300),
                        Categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.Categoryid, cascadeDelete: true)
                .Index(t => t.Categoryid);
            
            CreateTable(
                "dbo.SalesReports",
                c => new
                    {
                        SalesReportID = c.Int(nullable: false, identity: true),
                        SalesDate = c.DateTime(nullable: false),
                        Piece = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Productid = c.Int(nullable: false),
                        Currentid = c.Int(nullable: false),
                        Employeeid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReportID)
                .ForeignKey("dbo.Products", t => t.Productid, cascadeDelete: true)
                .ForeignKey("dbo.Currents", t => t.Currentid, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employeeid, cascadeDelete: true)
                .Index(t => t.Productid)
                .Index(t => t.Currentid)
                .Index(t => t.Employeeid);
            
            CreateTable(
                "dbo.Currents",
                c => new
                    {
                        CurrentID = c.Int(nullable: false, identity: true),
                        CurrentFirstName = c.String(nullable: false, maxLength: 30),
                        CurrentLastName = c.String(nullable: false, maxLength: 30),
                        CurrentCity = c.String(maxLength: 30),
                        CurrentMail = c.String(maxLength: 50),
                        Condition = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurrentID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeFirstName = c.String(maxLength: 30),
                        EmployeeLastName = c.String(maxLength: 30),
                        EmployeeImage = c.String(maxLength: 300),
                        Departmentid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Departments", t => t.Departmentid, cascadeDelete: true)
                .Index(t => t.Departmentid);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 30),
                        Condition = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseID = c.Int(nullable: false, identity: true),
                        ExpenseDescription = c.String(maxLength: 300),
                        ExpenseDate = c.DateTime(nullable: false),
                        ExpensePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceSerialNumber = c.String(maxLength: 10),
                        InvoiceRowNumber = c.String(maxLength: 30),
                        InvoiceDate = c.DateTime(nullable: false),
                        TaxAdministration = c.String(maxLength: 50),
                        TaxTime = c.DateTime(nullable: false),
                        Receiver = c.String(maxLength: 30),
                        Submitter = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.InvoiceContents",
                c => new
                    {
                        InvoiceContentID = c.Int(nullable: false, identity: true),
                        InvoiceDescription = c.String(maxLength: 300),
                        InvoiceAmount = c.String(maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_InvoiceID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceContentID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .Index(t => t.Invoice_InvoiceID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.InvoiceContents", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Employees", new[] { "Departmentid" });
            DropIndex("dbo.SalesReports", new[] { "Employeeid" });
            DropIndex("dbo.SalesReports", new[] { "Currentid" });
            DropIndex("dbo.SalesReports", new[] { "Productid" });
            DropIndex("dbo.Products", new[] { "Categoryid" });
            DropForeignKey("dbo.InvoiceContents", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Employees", "Departmentid", "dbo.Departments");
            DropForeignKey("dbo.SalesReports", "Employeeid", "dbo.Employees");
            DropForeignKey("dbo.SalesReports", "Currentid", "dbo.Currents");
            DropForeignKey("dbo.SalesReports", "Productid", "dbo.Products");
            DropForeignKey("dbo.Products", "Categoryid", "dbo.Categories");
            DropTable("dbo.InvoiceContents");
            DropTable("dbo.Invoices");
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Currents");
            DropTable("dbo.SalesReports");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
