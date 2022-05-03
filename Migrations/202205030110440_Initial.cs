namespace EXA_M03_JULIO_CAYAX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(),
                        DPI = c.String(),
                        Edad = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlumnoId)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Categoria = c.String(),
                        Descripcion = c.String(),
                        CatedraticoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId)
                .ForeignKey("dbo.Catedraticoes", t => t.CatedraticoId, cascadeDelete: true)
                .Index(t => t.CatedraticoId);
            
            CreateTable(
                "dbo.Catedraticoes",
                c => new
                    {
                        CatedraticoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(),
                        Especialidad = c.String(),
                    })
                .PrimaryKey(t => t.CatedraticoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumnoes", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Cursoes", "CatedraticoId", "dbo.Catedraticoes");
            DropIndex("dbo.Cursoes", new[] { "CatedraticoId" });
            DropIndex("dbo.Alumnoes", new[] { "CursoId" });
            DropTable("dbo.Catedraticoes");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Alumnoes");
        }
    }
}
