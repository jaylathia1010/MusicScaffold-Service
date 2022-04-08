namespace MusicScaffold.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Animation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
