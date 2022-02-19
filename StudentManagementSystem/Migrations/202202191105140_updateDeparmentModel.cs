namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDeparmentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DepartmentModels", "DeptName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DepartmentModels", "DeptName", c => c.String());
        }
    }
}
