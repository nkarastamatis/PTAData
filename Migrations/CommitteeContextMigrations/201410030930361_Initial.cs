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
                        CommitteeName = c.String(nullable: false, maxLength: 128),
                        EntryTitle = c.String(),
                        EntryBody = c.String(),
                    })
                .PrimaryKey(t => t.CommitteeName)
                .ForeignKey("dbo.Committees", t => t.CommitteeName)
                .Index(t => t.CommitteeName);
            
            CreateTable(
                "dbo.CommitteeFiles",
                c => new
                    {
                        CommitteeName = c.String(nullable: false, maxLength: 128),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.CommitteeName)
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
                "dbo.Members",
                c => new
                    {
                        MemberId = c.String(nullable: false, maxLength: 128),
                        Name_First = c.String(),
                        Name_Last = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        MembershipId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.Memberships", t => t.MembershipId, cascadeDelete: true)
                .ForeignKey("dbo.Committees", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.MembershipId);            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommitteeEntries", "CommitteeName", "dbo.Committees");
            DropForeignKey("dbo.Members", "MemberId", "dbo.Committees");
            DropForeignKey("dbo.Members", "MembershipId", "dbo.Memberships");
            DropForeignKey("dbo.CommitteeFiles", "CommitteeName", "dbo.Committees");
            DropIndex("dbo.Members", new[] { "MembershipId" });
            DropIndex("dbo.Members", new[] { "MemberId" });
            DropIndex("dbo.CommitteeFiles", new[] { "CommitteeName" });
            DropIndex("dbo.CommitteeEntries", new[] { "CommitteeName" });
            DropTable("dbo.Members");
            DropTable("dbo.Committees");
            DropTable("dbo.CommitteeFiles");
            DropTable("dbo.CommitteeEntries");
        }
    }
}
