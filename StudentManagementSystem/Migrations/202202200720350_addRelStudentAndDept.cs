namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelStudentAndDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentModels", "DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentModels", "DeptId");
            AddForeignKey("dbo.StudentModels", "DeptId", "dbo.DepartmentModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModels", "DeptId", "dbo.DepartmentModels");
            DropIndex("dbo.StudentModels", new[] { "DeptId" });
            DropColumn("dbo.StudentModels", "DeptId");
        }
    }
}
