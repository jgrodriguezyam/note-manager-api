using System;
using FluentMigrator;

namespace NoteManager.Migrations.Sprint_01
{
    [Migration(1)]
    public class _1_Seed : Migration
    {
        public override void Up()
        {
            #region User

            Create.Table("User").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("UserName").AsString(250).Unique().NotNullable()
                .WithColumn("Password").AsString(250).NotNullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            #endregion

            #region Company

            Create.Table("Company").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("Address").AsString(250).NotNullable()
                .WithColumn("Colony").AsString(250).NotNullable()
                .WithColumn("City").AsString(250).NotNullable()
                .WithColumn("Rfc").AsString(250).NotNullable()
                .WithColumn("OfficePhone").AsString(250).Nullable()
                .WithColumn("OfficeCellPhone").AsString(250).Nullable()
                .WithColumn("Date").AsDate().NotNullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            #endregion

            #region Customer

            Create.Table("Customer").InSchema("dbo")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Name").AsString(250).NotNullable()
                .WithColumn("LastName").AsString(250).NotNullable()
                .WithColumn("Gender").AsInt32().NotNullable()
                .WithColumn("Address").AsString(250).NotNullable()
                .WithColumn("Colony").AsString(250).NotNullable()
                .WithColumn("Municipality").AsString(250).NotNullable()
                .WithColumn("HomePhone").AsString(250).Nullable()
                .WithColumn("CellPhone").AsString(250).Nullable()

                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("ModifiedBy").AsInt32().NotNullable()
                .WithColumn("CreatedOn").AsDateTime().NotNullable()
                .WithColumn("ModifiedOn").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean();

            #endregion

            Init();

            //Execute.Sql("alter database NoteManager set allow_snapshot_isolation on");
        }

        public override void Down()
        {
            #region User

            Delete.Table("User").InSchema("dbo");

            #endregion

            #region Company

            Delete.Table("Company").InSchema("dbo");

            #endregion

            #region Customer

            Delete.Table("Customer").InSchema("dbo");

            #endregion
        }

        private void Init()
        {
            var today = DateTime.Now;
        }
    }
}