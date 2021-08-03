namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlForPostModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("common.Posts", "ImageUrl", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("common.Posts", "ImageUrl");
        }
    }
}
