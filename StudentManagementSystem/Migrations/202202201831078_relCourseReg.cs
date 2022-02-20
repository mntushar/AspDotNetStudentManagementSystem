namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relCourseReg : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StudentRegistrationModels", "CourseId");
            AddForeignKey("dbo.StudentRegistrationModels", "CourseId", "dbo.CourseModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentRegistrationModels", "CourseId", "dbo.CourseModels");
            DropIndex("dbo.StudentRegistrationModels", new[] { "CourseId" });
        }
    }
}
