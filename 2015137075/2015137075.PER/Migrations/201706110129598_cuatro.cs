namespace _2015137075.PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuatro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ventas", "CentroAtencion_CentroAtencionId", "dbo.CentroAtencions");
            DropForeignKey("dbo.Evaluacions", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Ventas", "Contrato_ContratoId", "dbo.Contratoes");
            DropForeignKey("dbo.Evaluacions", "LineaTelefonica_LineaTelefonicaId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.Evaluacions", "Plan_PlanId", "dbo.Plans");
            DropIndex("dbo.Ventas", new[] { "CentroAtencion_CentroAtencionId" });
            DropIndex("dbo.Ventas", new[] { "Contrato_ContratoId" });
            DropIndex("dbo.Evaluacions", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Evaluacions", new[] { "LineaTelefonica_LineaTelefonicaId" });
            DropIndex("dbo.Evaluacions", new[] { "Plan_PlanId" });
            RenameColumn(table: "dbo.Ventas", name: "CentroAtencion_CentroAtencionId", newName: "CentroAtencionId");
            RenameColumn(table: "dbo.Evaluacions", name: "Cliente_ClienteId", newName: "ClienteId");
            RenameColumn(table: "dbo.Ventas", name: "Contrato_ContratoId", newName: "ContratoId");
            RenameColumn(table: "dbo.Evaluacions", name: "LineaTelefonica_LineaTelefonicaId", newName: "LineaTelefonicaId");
            RenameColumn(table: "dbo.Evaluacions", name: "Plan_PlanId", newName: "PlanId");
            AddColumn("dbo.Ventas", "Nombre", c => c.String());
            AddColumn("dbo.Ventas", "EvaluacionId", c => c.Int(nullable: false));
            AddColumn("dbo.Evaluacions", "Nombre", c => c.String());
            AddColumn("dbo.Evaluacions", "TrabjadorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ventas", "CentroAtencionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ventas", "ContratoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Evaluacions", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Evaluacions", "LineaTelefonicaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Evaluacions", "PlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ventas", "CentroAtencionId");
            CreateIndex("dbo.Ventas", "ContratoId");
            CreateIndex("dbo.Ventas", "EvaluacionId");
            CreateIndex("dbo.Evaluacions", "LineaTelefonicaId");
            CreateIndex("dbo.Evaluacions", "PlanId");
            CreateIndex("dbo.Evaluacions", "ClienteId");
            AddForeignKey("dbo.Ventas", "EvaluacionId", "dbo.Evaluacions", "EvaluacionId", cascadeDelete: true);
            AddForeignKey("dbo.Ventas", "CentroAtencionId", "dbo.CentroAtencions", "CentroAtencionId", cascadeDelete: true);
            AddForeignKey("dbo.Evaluacions", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.Ventas", "ContratoId", "dbo.Contratoes", "ContratoId", cascadeDelete: true);
            AddForeignKey("dbo.Evaluacions", "LineaTelefonicaId", "dbo.LineaTelefonicas", "LineaTelefonicaId", cascadeDelete: true);
            AddForeignKey("dbo.Evaluacions", "PlanId", "dbo.Plans", "PlanId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.Evaluacions", "LineaTelefonicaId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.Ventas", "ContratoId", "dbo.Contratoes");
            DropForeignKey("dbo.Evaluacions", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Ventas", "CentroAtencionId", "dbo.CentroAtencions");
            DropForeignKey("dbo.Ventas", "EvaluacionId", "dbo.Evaluacions");
            DropIndex("dbo.Evaluacions", new[] { "ClienteId" });
            DropIndex("dbo.Evaluacions", new[] { "PlanId" });
            DropIndex("dbo.Evaluacions", new[] { "LineaTelefonicaId" });
            DropIndex("dbo.Ventas", new[] { "EvaluacionId" });
            DropIndex("dbo.Ventas", new[] { "ContratoId" });
            DropIndex("dbo.Ventas", new[] { "CentroAtencionId" });
            AlterColumn("dbo.Evaluacions", "PlanId", c => c.Int());
            AlterColumn("dbo.Evaluacions", "LineaTelefonicaId", c => c.Int());
            AlterColumn("dbo.Evaluacions", "ClienteId", c => c.Int());
            AlterColumn("dbo.Ventas", "ContratoId", c => c.Int());
            AlterColumn("dbo.Ventas", "CentroAtencionId", c => c.Int());
            DropColumn("dbo.Evaluacions", "TrabjadorId");
            DropColumn("dbo.Evaluacions", "Nombre");
            DropColumn("dbo.Ventas", "EvaluacionId");
            DropColumn("dbo.Ventas", "Nombre");
            RenameColumn(table: "dbo.Evaluacions", name: "PlanId", newName: "Plan_PlanId");
            RenameColumn(table: "dbo.Evaluacions", name: "LineaTelefonicaId", newName: "LineaTelefonica_LineaTelefonicaId");
            RenameColumn(table: "dbo.Ventas", name: "ContratoId", newName: "Contrato_ContratoId");
            RenameColumn(table: "dbo.Evaluacions", name: "ClienteId", newName: "Cliente_ClienteId");
            RenameColumn(table: "dbo.Ventas", name: "CentroAtencionId", newName: "CentroAtencion_CentroAtencionId");
            CreateIndex("dbo.Evaluacions", "Plan_PlanId");
            CreateIndex("dbo.Evaluacions", "LineaTelefonica_LineaTelefonicaId");
            CreateIndex("dbo.Evaluacions", "Cliente_ClienteId");
            CreateIndex("dbo.Ventas", "Contrato_ContratoId");
            CreateIndex("dbo.Ventas", "CentroAtencion_CentroAtencionId");
            AddForeignKey("dbo.Evaluacions", "Plan_PlanId", "dbo.Plans", "PlanId");
            AddForeignKey("dbo.Evaluacions", "LineaTelefonica_LineaTelefonicaId", "dbo.LineaTelefonicas", "LineaTelefonicaId");
            AddForeignKey("dbo.Ventas", "Contrato_ContratoId", "dbo.Contratoes", "ContratoId");
            AddForeignKey("dbo.Evaluacions", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
            AddForeignKey("dbo.Ventas", "CentroAtencion_CentroAtencionId", "dbo.CentroAtencions", "CentroAtencionId");
        }
    }
}
