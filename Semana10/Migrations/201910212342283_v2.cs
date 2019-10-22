namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Activo", c => c.Boolean());
            AddColumn("dbo.OfficeAssignments", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfficeAssignments", "Activo");
            DropColumn("dbo.People", "Activo");
        }
    }
}
