namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Transactions;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // var input = Console.ReadLine();
                //var lenght = int.Parse(Console.ReadLine());
                //DbInitializer.ResetDatabase(db);
                //Console.WriteLine(GetBooksByAgeRestriction(db));  // 1. Age Restriction
                //Console.WriteLine(GetGoldenBooks(db));    //2.Golden Books
                //Console.WriteLine(GetBooksByPrice(db));  //3.Books by Price
                //Console.WriteLine(GetBooksNotRealeasedIn(db));    //4.Not Released In
                //Console.WriteLine(GetBooksByCategory(db));    //5.Book Titles by Category
                //Console.WriteLine(GetBooksReleasedBefore(db,str));    //6.
                //Console.WriteLine(GetAuthorNamesEndingIn(db,input));  //7.
                // Console.WriteLine(GetBookTitlesContaining(db,input)); //8.
                //Console.WriteLine(GetBooksByAuthor(db, input));   //9.
                //Console.WriteLine($"There are {CountBooks(db, lenght)} books with longer title than {lenght} symbols"); //10.
                //Console.WriteLine(CountCopiesByAuthor(db)); //11.
                //Console.WriteLine(GetTotalProfitByCategory(db));  //12.
                //Console.WriteLine(GetMostRecentBooks(db));    //13.
                //IncreasePrices(db); //14.
                Console.WriteLine(RemoveBooks(db));
            }

        }

        public static int RemoveBooks(BookShopContext db)
        {
            var removed = db.Books
                .Where(b => b.Copies < 4200)
                .ToArray(); ;

            db.RemoveRange(removed);
            db.SaveChanges();

            return removed.Length;
        }

        public static void IncreasePrices(BookShopContext db)
        {

            var update = db.Books.Where(b => b.ReleaseDate.Value.Year < 2010 && b.ReleaseDate != null);


            foreach (var book in update)
            {
                book.Price += 5;
            }

            db.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext db)
        {
            return String.Join(Environment.NewLine, db.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalCopies = c.CategoryBooks
                        .Select(b => new
                        {
                            BookTitle = b.Book.Title,
                            TotalCopies = b.Book.Copies,
                            RecentYear = b.Book.ReleaseDate
                        })

                        .OrderByDescending(r => r.RecentYear)
                        .Take(3)
                })
                .OrderBy(c => c.CategoryName)
                .Select(x => $"--{x.CategoryName}{Environment.NewLine}{String.Join(Environment.NewLine, x.TotalCopies.Select(t => $"{t.BookTitle} ({t.RecentYear.Value.Year})"))}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            return String.Join(Environment.NewLine, db.Categories
                .Select(b => new
                {
                    CategoryName = b.Name,
                    TotalPrice = b.CategoryBooks
                        .Select(p => p.Book.Price * p.Book.Copies)
                        .Sum()
                })
                .OrderByDescending(t => t.TotalPrice)
                .ThenBy(n => n.CategoryName)
                .Select(c => $"{c.CategoryName} ${c.TotalPrice:f2}"));


        }

        public static string CountCopiesByAuthor(BookShopContext db)
        {
            return String.Join(Environment.NewLine, db.Authors
                 .Select(a => new
                 {
                     AuthorName = $"{a.FirstName} {a.LastName}",
                     CopiesCount = a.Books.Select(c => c.Copies).Sum()
                 })
                 .OrderByDescending(c => c.CopiesCount)
                 .Select(a => $"{a.AuthorName} - {a.CopiesCount}"));

        }

        public static int CountBooks(BookShopContext db, int lenght)
        {
            return db.Books.Where(t => t.Title.Length > lenght).Count();

        }

        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            return String.Join(Environment.NewLine, db.Books
                .Where(n => n.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(t => $"{t.Title} ({t.Author.FirstName} {t.Author.LastName})"));

        }

        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            return String.Join(Environment.NewLine, db.Books
                .Where(t => t.Title.ToLower().Contains(input.ToLower()))
                .Select(t => t.Title)
                .OrderBy(t => t));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext db, string input)
        {
            return string.Join(Environment.NewLine, db.Books
                .Where(n => n.Author.FirstName.EndsWith(input))
                .Select(n => $"{n.Author.FirstName} {n.Author.LastName}")
                .OrderBy(n => n)
                .Distinct());
        }

        public static string GetBooksReleasedBefore(BookShopContext db, string input)
        {
            var date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            return string.Join(Environment.NewLine, db.Books
                .Where(d => d.ReleaseDate < date)
                .OrderByDescending(d => d.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }

        public static string GetBooksByCategory(BookShopContext context, string input = null)
        {
            var list = new List<string>();

            if (input == null)
            {
                input = Console.ReadLine();
            }

            list = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            return String.Join(Environment.NewLine, context.Books
                .Where(c => c.BookCategories
                .Select(n => n.Category.Name.ToLower())
                .Intersect(list)
                .Any())
                .Select(t => t.Title)
                .OrderBy(t => t));

        }
        public static string GetBooksNotRealeasedIn(BookShopContext context, int? year = null)
        {
            if (year == null)
            {
                year = int.Parse(Console.ReadLine());
            }
            return String.Join(Environment.NewLine, context.Books
                .Where(y => y.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(t => $"A {t.Title}"));
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            return String.Join(Environment.NewLine, context.Books
                .Where(p => p.Price > 40)
                .OrderByDescending(p => p.Price)
                .Select(b => $"{b.Title} - ${b.Price:f2}"));
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            return string.Join(Environment.NewLine, context.Books
                    .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title));

        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string targetAgeGroup = null)
        {
            if (targetAgeGroup == null)
            {
                targetAgeGroup = Console.ReadLine();
            }

            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.AgeRestriction.ToString().Equals(targetAgeGroup, StringComparison.OrdinalIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(t => t));
        }
    }
}
