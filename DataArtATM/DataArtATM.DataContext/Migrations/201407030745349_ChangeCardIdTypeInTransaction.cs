namespace DataArtATM.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCardIdTypeInTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Transactions", new[] { "Card_Id" });
            DropColumn("dbo.Transactions", "CardId");
            RenameColumn(table: "dbo.Transactions", name: "Card_Id", newName: "CardId");
            AlterColumn("dbo.Transactions", "CardId", c => c.Long(nullable: false));
            AlterColumn("dbo.Transactions", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "CardId", c => c.Long(nullable: false));
            CreateIndex("dbo.Transactions", "CardId");
            AddForeignKey("dbo.Transactions", "CardId", "dbo.Cards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CardId", "dbo.Cards");
            DropIndex("dbo.Transactions", new[] { "CardId" });
            AlterColumn("dbo.Transactions", "CardId", c => c.Long());
            AlterColumn("dbo.Transactions", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transactions", "CardId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Transactions", name: "CardId", newName: "Card_Id");
            AddColumn("dbo.Transactions", "CardId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Transactions", "Card_Id");
            AddForeignKey("dbo.Transactions", "Card_Id", "dbo.Cards", "Id");
        }
    }
}
