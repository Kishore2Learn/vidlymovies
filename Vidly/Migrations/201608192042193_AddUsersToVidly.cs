namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersToVidly : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [PhoneNo]) VALUES (N'122d83bc-1bdb-4fc6-b26b-26855abe9704', N'admin@vidlymovies.com', 0, N'AH47Pmu5qxFceCvui5qg5HCr4Be9ju0vwGnNEGO8JiLJf+VhAARbdk531EMgLCj72A==', N'8f81f481-58c6-4916-814f-5d871d543159', NULL, 0, 0, NULL, 1, 0, N'admin@vidlymovies.com', N'0123456789')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [PhoneNo]) VALUES (N'339748fe-2afc-404e-b755-938eb22b1710', N'guest@vidlymovies.com', 0, N'AEeLQj+iCU3YWCYB4cW/LWqGh7TT9DsKeIRXcq9DR1tJeiVuH0v5lLB0Fu/xnYExBg==', N'54d9956d-cd02-496a-8d60-a0307583194e', NULL, 0, 0, NULL, 1, 0, N'guest@vidlymovies.com', N'1234567890')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c84c93d0-4902-47ed-b7df-bc9c4b7e6f06', N'CanManageRole')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'122d83bc-1bdb-4fc6-b26b-26855abe9704', N'c84c93d0-4902-47ed-b7df-bc9c4b7e6f06')
");
        }
        
        public override void Down()
        {
        }
    }
}
