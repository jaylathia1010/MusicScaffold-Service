namespace MusicScaffold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileExtensionPropertyToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "FileExtension", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "FileExtension");
        }
    }
}
