namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDisplayFromDisplay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FromDisplay", c => c.String());
            AddColumn("dbo.Messages", "ToDisplay", c => c.String());
            DropColumn("dbo.Messages", "FromID");
            DropColumn("dbo.Messages", "ToID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ToID", c => c.String());
            AddColumn("dbo.Messages", "FromID", c => c.String());
            DropColumn("dbo.Messages", "ToDisplay");
            DropColumn("dbo.Messages", "FromDisplay");
        }
    }
}
