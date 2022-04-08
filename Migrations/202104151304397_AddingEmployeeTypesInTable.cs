namespace MusicScaffold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployeeTypesInTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EmployeeTypes (Type) VALUES ('Full Time')");
            Sql("INSERT INTO EmployeeTypes (Type) VALUES ('Contract')");
            Sql("INSERT INTO EmployeeTypes (Type) VALUES ('Interns')");
        }
        
        public override void Down()
        {
        }
    }
}
