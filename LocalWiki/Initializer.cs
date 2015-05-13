using System;
using StructureMap;


namespace LocalWiki
{
    public static class Initializer
    {
        public static IFacade GetIniatializedFacade()
        {
            var container = new Container(x =>
            {
                x.For<IArticleRepository>().Use<ArticleRepository>();
                x.For<IAdminRepository>().Use<AdminRepository>();
                x.For<IAuthorRepository>().Use<AuthorRepository>();
                x.For<IUserRepository>().Use<UserRepository>();
                x.For<IFacade>().Use<Facade>();
            });

            var userRepository = container.GetInstance<IUserRepository>();
            var firstUser = new User("Nick", "Rusov", 20, 1);
            var secondUser = new User("Nickola", "Dusov", 24, 2);
            var thirdUser = new User("Nickola", "Shrusov", 22, 3);
            userRepository.AddUser(firstUser);
            userRepository.AddUser(secondUser);
            userRepository.AddUser(thirdUser);


            var authorRepository = container.GetInstance<IAuthorRepository>();
            var firstAuthor = new Author("Nickolay", "Pusov", 28, 4, "johndoe@example.com");
            var secondAuthor = new Author(firstUser, "jamesdon@example.com");
            var thirdAuthor = new Author(secondUser, "jamesdon@example.com");
            authorRepository.AddAuthor(new Author(thirdUser, "jamesdon@example.com"));
            authorRepository.AddAuthor(secondAuthor);
            authorRepository.AddAuthor(firstAuthor);
            authorRepository.AddAuthor(thirdAuthor);

            var adminRepository = container.GetInstance<IAdminRepository>();
            string[] privelegies = { "Delete articles", "Delete comments" };
            var firstAdmin = new Admin(firstAuthor, privelegies);
            var secondAdmin = new Admin(thirdAuthor, privelegies);
            adminRepository.AddAdmin(new Admin(thirdUser, privelegies));
            adminRepository.AddAdmin(firstAdmin);
            adminRepository.AddAdmin(secondAdmin);


            var article = new Article(new Author(secondAdmin, "mail:soap"), "C# classes", "Some text", 1);

            var firstComment = new Comment("Cool!", thirdAuthor, 1);
            article.AddComment(new Comment("Not bad.", secondAdmin, 2));
            var firstRating = new Rating(firstComment, 8);
            var secondRating = new Rating("Really cool!", firstAdmin, 10, 3);
            article.AddComment(firstComment);
            article.AddRating(firstRating);
            article.AddRating(secondRating);


            var articleRepository = container.GetInstance<IArticleRepository>();
            articleRepository.AddArticle(article);
            articleRepository.AddArticle(new Article(new Author("b", "Rusov", 20, 5, "mail address"), "C# interfaces",
                "Some text about interfaces", 2));
            articleRepository.AddArticle(new Article(new Author("c", "Rusov", 20, 6, "mail address"), "C# structures",
                "Some text about structures", 3));

            return container.
                With(articleRepository).
                With(authorRepository).
                With(adminRepository).
                With(userRepository).
                GetInstance<IFacade>(); 
        }
    }
}
