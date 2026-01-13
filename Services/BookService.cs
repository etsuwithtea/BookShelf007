using BookShelf007.Models;
using BookShelf007.Data;
using Microsoft.EntityFrameworkCore;

namespace BookShelf007.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetAllBooksAsync() => await _context.Books.ToListAsync();

    public async Task<Book?> GetBookByIdAsync(int id) => await _context.Books.FindAsync(id);

    public async Task AddBookAsync(Book book)
    {
        book.Id = 0;
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        var existingBook = await GetBookByIdAsync(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Description = book.Description;
            existingBook.ImageUrl = book.ImageUrl;
            existingBook.PublishedDate = book.PublishedDate;
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await GetBookByIdAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
