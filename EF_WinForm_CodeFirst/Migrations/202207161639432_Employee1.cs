namespace EF_WinForm_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        DOB = c.String(maxLength: 255),
                        Address = c.String(maxLength: 255),
                        ImageURL = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EmpID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
