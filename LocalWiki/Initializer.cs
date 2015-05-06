using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    public static class Initializer
    {
        public static Facade GetIniatializedFacade()
        {
            UserRepository userRepository = new UserRepository();
            User firstUser = new User("Nick", "Rusov", 20);
            User secondUser = new User("Nickola", "Dusov", 24);
            User thirdUser = new User("Nickola", "Shrusov", 22);
            userRepository.AddUser(firstUser);
            userRepository.AddUser(secondUser);
            userRepository.AddUser(thirdUser);

            AuthorRepository authorRepository = new AuthorRepository();
            Author firstAuthor= new Author("Nickolay", "Pusov", 28, "johndoe@example.com");
            Author secondAuthor = new Author(firstUser, "jamesdon@example.com");
            Author thirdAuthor = new Author(secondUser, "jamesdon@example.com");
            authorRepository.AddAuthor(new Author(thirdUser, "jamesdon@example.com"));
            authorRepository.AddAuthor(secondAuthor);
            authorRepository.AddAuthor(firstAuthor);
            authorRepository.AddAuthor(thirdAuthor);

            AdminRepository adminRepository = new AdminRepository();
            string[] privelegies = { "Delete articles", "Delete comments" };
            Admin firstAdmin = new Admin((User)firstAuthor, privelegies);
            Admin secondAdmin = new Admin((User)thirdAuthor, privelegies);
            adminRepository.AddAdmin(new Admin(thirdUser, privelegies));
            adminRepository.AddAdmin(firstAdmin);
            adminRepository.AddAdmin(secondAdmin);


            Article article = new Article(new Author(secondAdmin,"mail:soap"), "C# classes", "Some text");

            Comment firstComment= new Comment("Cool!", thirdAuthor);
            article.AddComment(new Comment("Not bad.", secondAdmin));
            Rating firstRating = new Rating(firstComment, 8);
            Rating secondRating = new Rating("Really cool!", firstAdmin, 10);
            article.AddComment(firstComment);
            article.AddRating(firstRating);
            article.AddRating(secondRating);

            ArticleRepository articleRepository = new ArticleRepository();
            articleRepository.AddArticle(article);
            articleRepository.AddArticle(new Article(new Author("b", "Rusov", 20, "mail address"), "C# interfaces",
                "Some text about interfaces"));
            articleRepository.AddArticle(new Article(new Author("c", "Rusov", 20, "mail address"), "C# structures",
                "Some text about structures"));
            var all = articleRepository.AllArticles;

            IArticleRepository IarticlesRepository = articleRepository;
            IAuthorRepository IauthorRepository = authorRepository;
            IAdminRepository IadminRepository = adminRepository;
            IUserRepository IuserRepository = userRepository;
            return new Facade(IarticlesRepository, authorRepository, adminRepository, userRepository);
        }
    }
}
