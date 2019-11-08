namespace ConsoleApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Salary = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                        mobile = c.String(),
                        DOB = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeLists", "Department_Id", "dbo.Departments");
            DropIndex("dbo.EmployeeLists", new[] { "Department_Id" });
            DropTable("dbo.EmployeeLists");
            DropTable("dbo.Departments");
        }
    }
}
