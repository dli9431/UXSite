namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QATest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QaTests",
                c => new
                    {
                        QaTestID = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Priority = c.String(),
                        Status = c.Int(),
                        Title = c.String(),
                        Instructions = c.String(),
                        Reward = c.Int(nullable: false),
                        Steps = c.String(),
                        Feedback = c.String(),
                        Locked = c.Boolean(nullable: false),
                        Skipped = c.Boolean(nullable: false),
                        Passed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QaTestID);
            
            CreateTable(
                "dbo.UserAttachments",
                c => new
                    {
                        UserAttachmentID = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        Location = c.String(),
                        AttachmentType = c.Int(),
                    })
                .PrimaryKey(t => t.UserAttachmentID);
            
            CreateTable(
                "dbo.QaTestApplicationUsers",
                c => new
                    {
                        QaTest_QaTestID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.QaTest_QaTestID, t.ApplicationUser_Id })
                .ForeignKey("dbo.QaTests", t => t.QaTest_QaTestID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.QaTest_QaTestID)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserAttachmentQaTests",
                c => new
                    {
                        UserAttachment_UserAttachmentID = c.Int(nullable: false),
                        QaTest_QaTestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserAttachment_UserAttachmentID, t.QaTest_QaTestID })
                .ForeignKey("dbo.UserAttachments", t => t.UserAttachment_UserAttachmentID, cascadeDelete: true)
                .ForeignKey("dbo.QaTests", t => t.QaTest_QaTestID, cascadeDelete: true)
                .Index(t => t.UserAttachment_UserAttachmentID)
                .Index(t => t.QaTest_QaTestID);
            
            AddColumn("dbo.AspNetUsers", "UserAttachment_UserAttachmentID", c => c.Int());
            AddColumn("dbo.Products", "QaTest_QaTestID", c => c.Int());
            AddColumn("dbo.Products", "UserAttachment_UserAttachmentID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserAttachment_UserAttachmentID");
            CreateIndex("dbo.Products", "QaTest_QaTestID");
            CreateIndex("dbo.Products", "UserAttachment_UserAttachmentID");
            AddForeignKey("dbo.Products", "QaTest_QaTestID", "dbo.QaTests", "QaTestID");
            AddForeignKey("dbo.AspNetUsers", "UserAttachment_UserAttachmentID", "dbo.UserAttachments", "UserAttachmentID");
            AddForeignKey("dbo.Products", "UserAttachment_UserAttachmentID", "dbo.UserAttachments", "UserAttachmentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserAttachment_UserAttachmentID", "dbo.UserAttachments");
            DropForeignKey("dbo.UserAttachmentQaTests", "QaTest_QaTestID", "dbo.QaTests");
            DropForeignKey("dbo.UserAttachmentQaTests", "UserAttachment_UserAttachmentID", "dbo.UserAttachments");
            DropForeignKey("dbo.AspNetUsers", "UserAttachment_UserAttachmentID", "dbo.UserAttachments");
            DropForeignKey("dbo.Products", "QaTest_QaTestID", "dbo.QaTests");
            DropForeignKey("dbo.QaTestApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.QaTestApplicationUsers", "QaTest_QaTestID", "dbo.QaTests");
            DropIndex("dbo.UserAttachmentQaTests", new[] { "QaTest_QaTestID" });
            DropIndex("dbo.UserAttachmentQaTests", new[] { "UserAttachment_UserAttachmentID" });
            DropIndex("dbo.QaTestApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.QaTestApplicationUsers", new[] { "QaTest_QaTestID" });
            DropIndex("dbo.Products", new[] { "UserAttachment_UserAttachmentID" });
            DropIndex("dbo.Products", new[] { "QaTest_QaTestID" });
            DropIndex("dbo.AspNetUsers", new[] { "UserAttachment_UserAttachmentID" });
            DropColumn("dbo.Products", "UserAttachment_UserAttachmentID");
            DropColumn("dbo.Products", "QaTest_QaTestID");
            DropColumn("dbo.AspNetUsers", "UserAttachment_UserAttachmentID");
            DropTable("dbo.UserAttachmentQaTests");
            DropTable("dbo.QaTestApplicationUsers");
            DropTable("dbo.UserAttachments");
            DropTable("dbo.QaTests");
        }
    }
}
