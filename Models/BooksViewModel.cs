namespace Mission11BradenToone.Models;

public class BooksViewModel
{
    public required List<Book> Books { get; set; }
    public Pagination Pagination { get; set; } = new Pagination();
}