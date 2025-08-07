using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Infrastructure.Persistence.Seeders
{
    public class SeededBooks
    {
        public static void AssignBookData(int bId, string bAuthor, int bPages, double bCost, DateOnly bPublishDate, Book book)
        {
            {
                book.ResourceId = bId;
                book.Author = bAuthor;
                book.Pages = bPages;
                book.Cost = bCost;
                book.PublishDate = bPublishDate;
            }
            ;
        }
    }
}
