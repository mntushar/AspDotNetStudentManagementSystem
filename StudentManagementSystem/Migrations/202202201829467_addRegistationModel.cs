namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRegistationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentRegistrationModels",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        IsPaymentComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentRegistrationModels");
        }
    }
}
