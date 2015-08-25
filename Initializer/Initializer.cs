using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Entities;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;
using StructureMap;


namespace FLS.LocalWiki.Initializing
{

    public sealed class SingleContainer
    {
        private static readonly SingleContainer s_instance = new SingleContainer();
        private static readonly Container s_container = new Container(x =>
                    {
                    x.For<IArticleRepository>().Use<DbArticleRepository>();
                    x.For<IAdminRepository>().Use<DbAdminRepository>();
                    x.For<IAuthorRepository>().Use<DbAuthorRepository>();
                    x.For<IUserRepository>().Use<DbUserRepository>();
                    x.For<IFacade>().Use<DbFacade>();
                    });
        private SingleContainer() { }

        public static SingleContainer Instance
        {
            get
            {
                return s_instance;
            }
        }

        public Container Container
        {
            get
            {
                return s_container;
            }
        }

        public IFacade GetFacade(string connectionString)
        {
            var userRepository = Instance.Container.With<string>(connectionString).GetInstance<IUserRepository>();
            var authorRepository = Instance.Container.With<string>(connectionString).GetInstance<IAuthorRepository>();
            var adminRepository = Instance.Container.With<string>(connectionString).GetInstance<IAdminRepository>();
            var articleRepository = Instance.Container.With<string>(connectionString).GetInstance<IArticleRepository>();
            var facade = Instance.Container.
               With<IArticleRepository>(articleRepository).
               With<IAuthorRepository>(authorRepository).
               With<IAdminRepository>(adminRepository).
               With<IUserRepository>(userRepository).
               GetInstance<IFacade>();
            return facade;
        }   
    }
      
   }
