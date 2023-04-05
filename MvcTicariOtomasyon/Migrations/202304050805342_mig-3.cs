namespace MvcTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceContents", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.InvoiceContents", new[] { "Invoice_InvoiceID" });
            RenameColumn(table: "dbo.InvoiceContents", name: "Invoice_InvoiceID", newName: "Invoiceid");
            AddForeignKey("dbo.InvoiceContents", "Invoiceid", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            CreateIndex("dbo.InvoiceContents", "Invoiceid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.InvoiceContents", new[] { "Invoiceid" });
            DropForeignKey("dbo.InvoiceContents", "Invoiceid", "dbo.Invoices");
            RenameColumn(table: "dbo.InvoiceContents", name: "Invoiceid", newName: "Invoice_InvoiceID");
            CreateIndex("dbo.InvoiceContents", "Invoice_InvoiceID");
            AddForeignKey("dbo.InvoiceContents", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID");
        }
    }
}
