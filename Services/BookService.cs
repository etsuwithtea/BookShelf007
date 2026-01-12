using BookShelf007.Models;
namespace BookShelf007.Services;

public class BookService : IBookService
{
    private List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "One Piece", Author = "Eiichiro Oda", Description = "The story follows the adventures of Monkey D. Luffy and his pirate crew in order to find the greatest treasure ever left by the legendary Pirate, Gold Roger.", PublishedDate = new DateTime(1997, 7, 22), ImageUrl = "https://cdn.myanimelist.net/images/manga/2/253146.jpg" },
        new Book { Id = 3, Title = "Naruto", Author = "Masashi Kishimoto", Description = "Naruto Uzumaki, a mischievous adolescent ninja, struggles as he searches for recognition from the village.", PublishedDate = new DateTime(1999, 9, 21), ImageUrl = "https://cdn.myanimelist.net/images/manga/3/117681.jpg" },
        new Book { Id = 4, Title = "Chainsaw Man", Author = "Tatsuki Fujimoto", Description = "Denji is a teenage boy living with a Chainsaw Devil named Pochita.", PublishedDate = new DateTime(2018, 12, 3), ImageUrl = "https://cdn.myanimelist.net/images/manga/3/216464.jpg" }
    };

    public List<Book> GetAllBooks() => _books;

    public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void AddBook(Book book)
    {
        book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
        _books.Add(book);
    }

    public void UpdateBook(Book book)
    {
        var existingBook = GetBookById(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.ImageUrl = book.ImageUrl;
            existingBook.PublishedDate = book.PublishedDate;
        }
    }

    public void DeleteBook(int id)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            _books.Remove(book);
        }
    }
}
