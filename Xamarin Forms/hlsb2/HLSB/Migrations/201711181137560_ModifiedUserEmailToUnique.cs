namespace HLSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedUserEmailToUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "EmailAddress", c => c.String(maxLength: 200));
            CreateIndex("dbo.Users", "EmailAddress", unique: true, name: "Email_Idx");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "Email_Idx");
            AlterColumn("dbo.Users", "EmailAddress", c => c.String());
        }
    }
}
