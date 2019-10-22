namespace Semana10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        title_ = c.String(maxLength: 50),
                        Credits = c.Int(nullable: false),
                        DepartamentoID = c.Int(nullable: false),
                        Instructor_ID = c.Int(),
                        Department_DepartamentID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.People", t => t.Instructor_ID)
                .ForeignKey("dbo.Departments", t => t.Department_DepartamentID)
                .Index(t => t.Instructor_ID)
                .Index(t => t.Department_DepartamentID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        EnrollmentDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartamentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DepartamentID)
                .ForeignKey("dbo.People", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.People", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Department_DepartamentID", "dbo.Departments");
            DropForeignKey("dbo.Departments", "InstructorID", "dbo.People");
            DropForeignKey("dbo.OfficeAssignments", "InstructorID", "dbo.People");
            DropForeignKey("dbo.Courses", "Instructor_ID", "dbo.People");
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.People");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropIndex("dbo.OfficeAssignments", new[] { "InstructorID" });
            DropIndex("dbo.Departments", new[] { "InstructorID" });
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.Courses", new[] { "Department_DepartamentID" });
            DropIndex("dbo.Courses", new[] { "Instructor_ID" });
            DropTable("dbo.OfficeAssignments");
            DropTable("dbo.Departments");
            DropTable("dbo.People");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
