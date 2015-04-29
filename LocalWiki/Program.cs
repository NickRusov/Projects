using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalWiki
{
    class Program
    {
        static void Main()
        {
            UserRepository userRepo = new UserRepository();
            User firstUser = new User("Nick", "Rusov", 20);
            User secondUser = new User("Nickola", "Dusov", 24);
            User user3 = new User("Nickola", "Shrusov", 24);
            userRepo.AddUser(firstUser);
            userRepo.AddUser(secondUser);
            userRepo.AddUser(user3);

            AuthorRepository authorRepo = new AuthorRepository();
            Author author = new Author("Nickolay", "Pusov", 28, "johndoe@example.com");
            Author author1 = new Author(firstUser, "jamesdon@example.com");
            Author author2 = new Author(secondUser, "jamesdon@example.com");
            authorRepo.AddAuthor(new Author(user3, "jamesdon@example.com"));

            AdminRepository adminRepo = new AdminRepository();
            string[] privelegies = {"Delete articles","Delete comments"};
            Admin ad = new Admin(author,privelegies);
            Admin ad2 = new Admin(author2, privelegies);
            adminRepo.AddAdmin(new Admin(user3, privelegies));


            Article art = new Article(author1, "C# classes", "Some text");
            Comment comment1 = new Comment("Cool!", user3);
            art.AddComment(new Comment("Not bad.", ad2));
            Rating rating1 = new Rating(comment1, 8);
            Rating rating2 = new Rating("Really cool!", ad, 10);    //
            art.AddComment(comment1);
            art.AddRating(rating1);
            art.AddRating(rating2);
            /*Console.WriteLine(art.Id);
            Console.WriteLine(comment1.Id);
            Console.WriteLine(rating1.Id);
            Console.WriteLine(rating2.Id);
            Console.WriteLine();*/

            ArticleRepository repo = new ArticleRepository();
            repo.AddArticle(art);
            //Console.WriteLine(repo.Count());
            var all = repo.AllArticles;
            /*Console.WriteLine(all.Last().Author.FirstName);
            Console.Write(all.Last().Author.LastName);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(user3);
            Console.WriteLine(ad);
            Console.WriteLine(author1);
            Console.WriteLine(art);
            Console.WriteLine(comment1);
            Console.WriteLine(rating1);
            Report.Show(art);*/
            //Console.Write(Facade.FindId(repo, 2));
            Facade facade = new Facade(repo, authorRepo, adminRepo, userRepo);
            //facade.IAdmins.Find(1);
            IArticles iArticle = (IArticles)facade;
            

            Report.Show(facade.GetArticleAverageRating(1));
            Report.Show(iArticle.Find(1));



        }
    }
}
