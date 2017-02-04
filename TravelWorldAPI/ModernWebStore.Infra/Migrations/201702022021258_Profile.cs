namespace ModernWebStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 60),
                        idCountry = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id, cascadeDelete: true)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 60),
                        idContinent = c.Int(nullable: false),
                        continent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Continent", t => t.continent_Id, cascadeDelete: true)
                .Index(t => t.continent_Id);
            
            CreateTable(
                "dbo.Continent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 60),
                        description = c.String(nullable: false, maxLength: 2000),
                        date = c.DateTime(nullable: false),
                        picture = c.String(maxLength: 200),
                        txtPicture = c.String(maxLength: 100),
                        video = c.String(maxLength: 200),
                        idCategory = c.Int(nullable: false),
                        idContinent = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        category_Id = c.Int(nullable: false),
                        continent_Id = c.Int(nullable: false),
                        users_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Continent", t => t.continent_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.users_Id, cascadeDelete: true)
                .Index(t => t.category_Id)
                .Index(t => t.continent_Id)
                .Index(t => t.users_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 160),
                        Password = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "users_Id", "dbo.User");
            DropForeignKey("dbo.Post", "continent_Id", "dbo.Continent");
            DropForeignKey("dbo.Post", "category_Id", "dbo.Category");
            DropForeignKey("dbo.City", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.Country", "continent_Id", "dbo.Continent");
            DropIndex("dbo.Post", new[] { "users_Id" });
            DropIndex("dbo.Post", new[] { "continent_Id" });
            DropIndex("dbo.Post", new[] { "category_Id" });
            DropIndex("dbo.Country", new[] { "continent_Id" });
            DropIndex("dbo.City", new[] { "Country_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Post");
            DropTable("dbo.Continent");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Category");
        }
    }
}
