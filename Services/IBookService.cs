using BookShelf007.Models;

namespace BookShelf007.Services;

public interface IBookService
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
    Task ToggleFavoriteAsync(int id);
    Task<BookStatistics> GetStatisticsAsync();
}

public class BookStatistics
{
    public int TotalBooks { get; set; }
    public int FavoriteBooks { get; set; }
    public List<Book> RecentBooks { get; set; } = new();
}
