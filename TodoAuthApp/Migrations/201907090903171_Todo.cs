namespace TodoAuthApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Todo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Done = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Todoes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Todoes", new[] { "User_Id" });
            DropTable("dbo.Todoes");
        }
    }
}
