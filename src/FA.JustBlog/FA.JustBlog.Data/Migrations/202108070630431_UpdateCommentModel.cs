namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCommentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("common.Comments", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("common.Comments", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("common.Comments", "CommentHeader", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("common.Comments", "CommentText", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("common.Comments", "CommentText", c => c.String());
            AlterColumn("common.Comments", "CommentHeader", c => c.String());
            AlterColumn("common.Comments", "Email", c => c.String());
            AlterColumn("common.Comments", "Name", c => c.String());
        }
    }
}
