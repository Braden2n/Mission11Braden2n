namespace Mission11BradenToone.Models;

public interface IBookstoreRepo
{
    public IQueryable<Book> Books { get; }
}