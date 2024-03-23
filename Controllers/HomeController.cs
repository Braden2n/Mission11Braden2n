using Microsoft.AspNetCore.Mvc;
using Mission11BradenToone.Models;

namespace Mission11BradenToone.Controllers;

public class HomeController(IBookstoreRepo repo) : Controller
{
    public IActionResult Index(int pageNum)
    {
        const int pageSize = 10;
        BooksViewModel model = new BooksViewModel
        {
            Books = repo.Books
                .OrderBy(x => x.BookId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),
            Pagination = new Pagination
            {
                CurrentPage = pageNum,
                ItemsPerPage = pageSize,
                TotalItems = repo.Books.Count()
            }
        };
        return View(model);
    }
}