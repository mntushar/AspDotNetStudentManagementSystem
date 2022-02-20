namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relStdentReg : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.StudentRegistrationModels");
            AlterColumn("dbo.StudentRegistrationModels", "StudentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.StudentRegistrationModels", "StudentId");
            CreateIndex("dbo.StudentRegistrationModels", "StudentId");
            AddForeignKey("dbo.StudentRegistrationModels", "StudentId", "dbo.StudentModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentRegistrationModels", "StudentId", "dbo.StudentModels");
            DropIndex("dbo.StudentRegistrationModels", new[] { "StudentId" });
            DropPrimaryKey("dbo.StudentRegistrationModels");
            AlterColumn("dbo.StudentRegistrationModels", "StudentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.StudentRegistrationModels", "StudentId");
        }
    }
}
