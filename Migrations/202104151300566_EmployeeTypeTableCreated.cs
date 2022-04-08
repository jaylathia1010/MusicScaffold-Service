namespace MusicScaffold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTypeTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "EmployeeTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "EmployeeTypeId");
            AddForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeTypeId", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "EmployeeTypeId" });
            DropColumn("dbo.Employees", "EmployeeTypeId");
            DropTable("dbo.EmployeeTypes");
        }
    }
}
