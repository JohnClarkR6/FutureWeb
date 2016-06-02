using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureWeb.Models
{
    public class User
    {
        private const int WorkFactor = 13;

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword("", WorkFactor);
        }

        public virtual int Id { get; set; }                    //needs to be virtual to be mapped by NHibernate
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }

        public virtual IList<Role> Roles { get; set; }     //puts all the roles into a list 

        public User()
        {
            Roles = new List<Role>();
        }

        public virtual void SetPassword(string password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }

    public class UserMap : ClassMapping<User>   //inherets from the ClassMapping class
    {
        public UserMap()            
        {
            Table("users");                   //tell NHiberate which table to use

            Id(x => x.Id, x => x.Generator(Generators.Identity));     //tells HBibernate which is the primary key ID and that the database incrmentes the PK

            Property(x => x.Username, x => x.NotNullable(true));    
            Property(x => x.Email, x => x.NotNullable(true));
            Property(x => x.PasswordHash, x =>
            {
                x.Column("password_hash");
                x.NotNullable(true);
            });

            Bag(x => x.Roles, x =>                      //Bag is a collection from NHibernate, the abbility to relate an enitity to another entity
            {
                x.Table("role_users");                              //name of pivoit table
                x.Key(k => k.Column("user_id"));                    //column that represents the users table 
            }, x => x.ManyToMany(k => k.Column("role_id")));        //many to many as there many be more roles , and specify column with roles
        }
    }
}