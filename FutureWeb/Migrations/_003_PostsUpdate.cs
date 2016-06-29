using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FutureWeb.Migrations
{
    [Migration(3)]
    public class _002_PostsUpdate : Migration
    {
        public override void Down()
        {
            Delete.Column("description").FromTable("posts");
            Delete.Column("topic").FromTable("posts");        
        }

        public override void Up()
        {
            Alter.Table("posts")
               .AddColumn("description").AsCustom("TEXT")
               .AddColumn("topic").AsString(128);
        }
  
    }
}
