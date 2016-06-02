using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureWeb.Migrations
{
    [Migration(1)]  //attribute tells fluentmigrator which version the migration is
    public class _001_UsersAndRoles : Migration   
    {
        public override void Down()                  //tells fluentmigrator to go down
        {
            Delete.Table("role_users");
            Delete.Table("roles");
            Delete.Table("users");


        }

        public override void Up()                 //tells fluentmigrator to go up
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(123)
                .WithColumn("email").AsCustom("VARCHAR(256)")
                .WithColumn("password_hash").AsString(128);

            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);

            Create.Table("role_users")
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);
        }
    }
}
