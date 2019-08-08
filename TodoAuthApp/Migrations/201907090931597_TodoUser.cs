namespace TodoAuthApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoUser : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Todoes", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Todoes", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Todoes", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Todoes", name: "UserId", newName: "User_Id");
        }
    }
}
