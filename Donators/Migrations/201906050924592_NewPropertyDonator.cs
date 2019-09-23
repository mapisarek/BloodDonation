namespace Donators.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertyDonator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Donators", "IsDataValid", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Donators", "BloodAmount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donators", "BloodAmount", c => c.Int(nullable: false));
            DropColumn("dbo.Donators", "IsDataValid");
        }
    }
}
