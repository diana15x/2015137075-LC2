namespace _2015137075.PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Evaluacions",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        Cliente_ClienteId = c.Int(),
                        LineaTelefonica_LineaTelefonicaId = c.Int(),
                        Plan_PlanId = c.Int(),
                        Trabajador_TrabajadorId = c.Int(),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .ForeignKey("dbo.LineaTelefonicas", t => t.LineaTelefonica_LineaTelefonicaId)
                .ForeignKey("dbo.Plans", t => t.Plan_PlanId)
                .ForeignKey("dbo.Trabajadors", t => t.Trabajador_TrabajadorId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.LineaTelefonica_LineaTelefonicaId)
                .Index(t => t.Plan_PlanId)
                .Index(t => t.Trabajador_TrabajadorId);
            
            CreateTable(
                "dbo.Contratoes",
                c => new
                    {
                        ContratoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ContratoId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        Contrato_ContratoId = c.Int(),
                        CentroAtencion_CentroAtencionId = c.Int(),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Contratoes", t => t.Contrato_ContratoId)
                .ForeignKey("dbo.CentroAtencions", t => t.CentroAtencion_CentroAtencionId)
                .Index(t => t.Contrato_ContratoId)
                .Index(t => t.CentroAtencion_CentroAtencionId);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .ForeignKey("dbo.Departamentoes", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Distritoes",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ProvinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistritoId)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        DistritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Distritoes", t => t.DistritoId, cascadeDelete: true)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.CentroAtencions",
                c => new
                    {
                        CentroAtencionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DireccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentroAtencionId)
                .ForeignKey("dbo.Direccions", t => t.DireccionId, cascadeDelete: true)
                .Index(t => t.DireccionId);
            
            CreateTable(
                "dbo.LineaTelefonicas",
                c => new
                    {
                        LineaTelefonicaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.LineaTelefonicaId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.Trabajadors",
                c => new
                    {
                        TrabajadorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TrabajadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "Trabajador_TrabajadorId", "dbo.Trabajadors");
            DropForeignKey("dbo.Evaluacions", "Plan_PlanId", "dbo.Plans");
            DropForeignKey("dbo.Evaluacions", "LineaTelefonica_LineaTelefonicaId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.Distritoes", "ProvinciaId", "dbo.Provincias");
            DropForeignKey("dbo.Direccions", "DistritoId", "dbo.Distritoes");
            DropForeignKey("dbo.Ventas", "CentroAtencion_CentroAtencionId", "dbo.CentroAtencions");
            DropForeignKey("dbo.CentroAtencions", "DireccionId", "dbo.Direccions");
            DropForeignKey("dbo.Provincias", "DepartamentoId", "dbo.Departamentoes");
            DropForeignKey("dbo.Ventas", "Contrato_ContratoId", "dbo.Contratoes");
            DropForeignKey("dbo.Evaluacions", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.CentroAtencions", new[] { "DireccionId" });
            DropIndex("dbo.Direccions", new[] { "DistritoId" });
            DropIndex("dbo.Distritoes", new[] { "ProvinciaId" });
            DropIndex("dbo.Provincias", new[] { "DepartamentoId" });
            DropIndex("dbo.Ventas", new[] { "CentroAtencion_CentroAtencionId" });
            DropIndex("dbo.Ventas", new[] { "Contrato_ContratoId" });
            DropIndex("dbo.Evaluacions", new[] { "Trabajador_TrabajadorId" });
            DropIndex("dbo.Evaluacions", new[] { "Plan_PlanId" });
            DropIndex("dbo.Evaluacions", new[] { "LineaTelefonica_LineaTelefonicaId" });
            DropIndex("dbo.Evaluacions", new[] { "Cliente_ClienteId" });
            DropTable("dbo.Trabajadors");
            DropTable("dbo.Plans");
            DropTable("dbo.LineaTelefonicas");
            DropTable("dbo.CentroAtencions");
            DropTable("dbo.Direccions");
            DropTable("dbo.Distritoes");
            DropTable("dbo.Provincias");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Ventas");
            DropTable("dbo.Contratoes");
            DropTable("dbo.Evaluacions");
            DropTable("dbo.Clientes");
        }
    }
}
