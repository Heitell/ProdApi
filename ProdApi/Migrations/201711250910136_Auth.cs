namespace ProdApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auth : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserProducts", name: "Users_Id", newName: "User_Id");
            RenameIndex(table: "dbo.UserProducts", name: "IX_Users_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserProducts", name: "IX_User_Id", newName: "IX_Users_Id");
            RenameColumn(table: "dbo.UserProducts", name: "User_Id", newName: "Users_Id");
        }
    }
}
