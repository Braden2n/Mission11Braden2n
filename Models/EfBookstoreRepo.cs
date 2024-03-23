namespace Mission11BradenToone.Models;

public class EfBookstoreRepo(BookstoreContext context) : IBookstoreRepo
{
    public IQueryable<Book> Books => context.Books;
}