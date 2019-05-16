namespace Agiblock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "owner_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "owner_Id" });
            AlterColumn("dbo.Books", "owner_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "owner_Id");
            AddForeignKey("dbo.Books", "owner_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "owner_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "owner_Id" });
            AlterColumn("dbo.Books", "owner_Id", c => c.Int());
            CreateIndex("dbo.Books", "owner_Id");
            AddForeignKey("dbo.Books", "owner_Id", "dbo.Users", "Id");
        }
    }
}
