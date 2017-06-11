namespace _2015137075.PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationcinco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evaluacions", "Trabajador_TrabajadorId", "dbo.Trabajadors");
            DropIndex("dbo.Evaluacions", new[] { "Trabajador_TrabajadorId" });
            RenameColumn(table: "dbo.Evaluacions", name: "Trabajador_TrabajadorId", newName: "TrabajadorId");
            AlterColumn("dbo.Evaluacions", "TrabajadorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Evaluacions", "TrabajadorId");
            AddForeignKey("dbo.Evaluacions", "TrabajadorId", "dbo.Trabajadors", "TrabajadorId", cascadeDelete: true);
            DropColumn("dbo.Evaluacions", "TrabjadorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evaluacions", "TrabjadorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Evaluacions", "TrabajadorId", "dbo.Trabajadors");
            DropIndex("dbo.Evaluacions", new[] { "TrabajadorId" });
            AlterColumn("dbo.Evaluacions", "TrabajadorId", c => c.Int());
            RenameColumn(table: "dbo.Evaluacions", name: "TrabajadorId", newName: "Trabajador_TrabajadorId");
            CreateIndex("dbo.Evaluacions", "Trabajador_TrabajadorId");
            AddForeignKey("dbo.Evaluacions", "Trabajador_TrabajadorId", "dbo.Trabajadors", "TrabajadorId");
        }
    }
}
