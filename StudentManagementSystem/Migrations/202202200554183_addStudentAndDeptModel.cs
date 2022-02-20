namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentAndDeptModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentModels");
            DropTable("dbo.DepartmentModels");
        }
    }
}
