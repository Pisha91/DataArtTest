namespace DataArtATM.DataContext.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        PinCode = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsBlocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number, unique: true);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardId = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Card_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Transactions", new[] { "Card_Id" });
            DropIndex("dbo.Cards", new[] { "Number" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Cards");
        }
    }
}
