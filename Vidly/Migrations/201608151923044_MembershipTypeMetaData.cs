namespace VidlyMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeMetaData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes (Id,MemberShipDescription, SignUpFee, DurationInMonths, DiscountRate) VALUES (1,'Pay As You Go',0,0,0)");
            Sql("insert into MembershipTypes (Id,MemberShipDescription, SignUpFee, DurationInMonths, DiscountRate) VALUES (2,'Monthly',30,1,10)");
            Sql("insert into MembershipTypes (Id,MemberShipDescription, SignUpFee, DurationInMonths, DiscountRate) VALUES (3,'Quarterly',90,3,5)");
            Sql("insert into MembershipTypes (Id,MemberShipDescription, SignUpFee, DurationInMonths, DiscountRate) VALUES (4,'Yearly',150,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
