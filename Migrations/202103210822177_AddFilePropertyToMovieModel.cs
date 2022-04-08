namespace MusicScaffold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFilePropertyToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "byteFile", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "byteFile");
        }
    }
}
