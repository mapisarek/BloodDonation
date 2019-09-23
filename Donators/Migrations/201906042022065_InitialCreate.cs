namespace Donators.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Pesel = c.String(),
                        Place = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                        BloodType = c.String(),
                        BloodAmount = c.Int(nullable: false),
                        BloodFactor = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donators");
        }
    }
}
