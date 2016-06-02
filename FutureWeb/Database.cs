using FutureWeb.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutureWeb
{
    public static class Database
    {

        private const string SessionKey = "FutureWeb.Database.Sessionkey";

        private static ISessionFactory _sessionFactory;  

        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SessionKey]; }
        }


        public static void Configure()   //class to configure NHibernate
        {
            var config = new Configuration();  //hosts the mapping and connection string and will result in a session factory

            // configure the connection string - inside web.config
            config.Configure();

            // add our mappings
            var mapper = new ModelMapper();        
            mapper.AddMapping<UserMap>();    //tell mapper about the mapping in models
            mapper.AddMapping<RoleMap>();
            mapper.AddMapping<TagMap>();
            mapper.AddMapping<PostMap>();


            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());  //tell config about the result of compling the mappings

            // create session factory
            _sessionFactory = config.BuildSessionFactory();     
        }

        public static void OpenSession() //opened at the begining of every request
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }


        public static void CloseSession()  //responsible for closing each session
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                session.Close();

            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}