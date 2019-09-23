namespace Donators.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDonatorModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donators", "DonationDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donators", "DonationDate", c => c.DateTime(nullable: false));
        }
    }
}
