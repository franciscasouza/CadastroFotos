namespace CadastroFotos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FistDados2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Alunoes");
        }
    }
}
