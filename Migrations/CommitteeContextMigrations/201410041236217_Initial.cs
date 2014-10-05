namespace PTAData.Migrations.CommitteeContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommitteeEntries",
                c => new
                    {
                        EntryId = c.String(nullable: false, maxLength: 128),
                        CommitteeName = c.String(maxLength: 128),
                        EntryTitle = c.String(),
                        EntryBody = c.String(),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Committees", t => t.CommitteeName)
                .Index(t => t.CommitteeName);
            
            CreateTable(
                "dbo.CommitteeFiles",
                c => new
                    {
                        FileName = c.String(nullable: false, maxLength: 128),
                        CommitteeName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileName)
                .ForeignKey("dbo.Committees", t => t.CommitteeName)
                .Index(t => t.CommitteeName);
            
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        CommitteeName = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CommitteeName);
            
            CreateTable(
                "dbo.ChairPersons",
                c => new
                    {
                        CommitteeName = c.String(nullable: false, maxLength: 128),
                        MemberId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CommitteeName, t.MemberId })
                .ForeignKey("dbo.Committees", t => t.CommitteeName, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.CommitteeName)
                .Index(t => t.MemberId);
            
                       
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommitteeEntries", "CommitteeName", "dbo.Committees");
            DropForeignKey("dbo.ChairPersons", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Students", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "StudentId", "dbo.Memberships");
            DropForeignKey("dbo.ChairPersons", "CommitteeName", "dbo.Committees");
            DropForeignKey("dbo.CommitteeFiles", "CommitteeName", "dbo.Committees");
            DropIndex("dbo.ChairPersons", new[] { "MemberId" });
            DropIndex("dbo.ChairPersons", new[] { "CommitteeName" });
            DropIndex("dbo.CommitteeFiles", new[] { "CommitteeName" });
            DropIndex("dbo.CommitteeEntries", new[] { "CommitteeName" });
            DropTable("dbo.ChairPersons");
            DropTable("dbo.Committees");
            DropTable("dbo.CommitteeFiles");
            DropTable("dbo.CommitteeEntries");
        }
    }
}
