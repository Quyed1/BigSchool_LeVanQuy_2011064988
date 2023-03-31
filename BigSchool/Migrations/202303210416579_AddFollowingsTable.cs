namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "Followee_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_FollowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_Followee_Id", newName: "IX_FolloweeId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            DropColumn("dbo.Followings", "FollowingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "FollowingId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", "FollowingId");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_Followee_Id");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "Followee_Id");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "Follower_Id");
        }
    }
}
