namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationStudenAndDept : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StudentModels", "DeptId");
            AddForeignKey("dbo.StudentModels", "DeptId", "dbo.DepartmentModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentModels", "DeptId", "dbo.DepartmentModels");
            DropIndex("dbo.StudentModels", new[] { "DeptId" });
        }
    }
}
