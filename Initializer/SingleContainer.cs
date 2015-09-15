using FLS.LocalWiki.Models;
using FLS.LocalWiki.Models.Interfaces;
using FLS.LocalWiki.Models.Repositories;
using StructureMap;


namespace FLS.LocalWiki.Initializing
{

    public sealed class SingleContainer
    {
        private static readonly SingleContainer s_instance = new SingleContainer();
        private static readonly Container s_container = new Container(x => x.For<IFacade>().Use<Facade>());
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
            var facade = Instance.Container.
               With<IArticleRepository>(new ArticleRepository(connectionString)).
               With<IAuthorRepository>(new AuthorRepository(connectionString)).
               With<IAdminRepository>(new AdminRepository(connectionString)).
               With<IUserRepository>(new UserRepository(connectionString)).
               GetInstance<IFacade>();
            return facade;
        }
    }
      
   }
