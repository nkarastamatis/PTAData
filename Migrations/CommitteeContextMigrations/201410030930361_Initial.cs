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
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        MembershipId = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Address_StreetAddress = c.String(),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        Address_Zip = c.String(),
                    })
                .PrimaryKey(t => t.MembershipId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        Name_First = c.String(),
                        Name_Last = c.String(),
                        MembershipId = c.String(nullable: false),
                        TeacherId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Memberships", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        Name_First = c.String(),
                        Name_Last = c.String(),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommitteeEntries", "CommitteeName", "dbo.Committees");
            DropForeignKey("dbo.Members", "MemberId", "dbo.Committees");
            DropForeignKey("dbo.Students", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Students", "StudentId", "dbo.Memberships");
            DropForeignKey("dbo.Members", "MembershipId", "dbo.Memberships");
            DropForeignKey("dbo.CommitteeFiles", "CommitteeName", "dbo.Committees");
            DropIndex("dbo.Students", new[] { "TeacherId" });
            DropIndex("dbo.Students", new[] { "StudentId" });
            DropIndex("dbo.Members", new[] { "MembershipId" });
            DropIndex("dbo.Members", new[] { "MemberId" });
            DropIndex("dbo.CommitteeFiles", new[] { "CommitteeName" });
            DropIndex("dbo.CommitteeEntries", new[] { "CommitteeName" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Memberships");
            DropTable("dbo.Members");
            DropTable("dbo.Committees");
            DropTable("dbo.CommitteeFiles");
            DropTable("dbo.CommitteeEntries");
        }
    }
}
