using BookShelf007.Models;
namespace BookShelf007.Services;

public class BookService : IBookService
{
    private List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "One Piece", Author = "Eiichiro Oda", Description = "The story follows the adventures of Monkey D. Luffy and his pirate crew in order to find the greatest treasure ever left by the legendary Pirate, Gold Roger.", PublishedDate = new DateTime(1997, 7, 22), ImageUrl = "https://cdn.myanimelist.net/images/manga/2/253146.jpg" },
        new Book { Id = 2, Title = "Dragon Ball", Author = "Akira Toriyama", Description = "Bulma is a girl in search of the magical Dragon Balls, which when combined, can grant any wish.", PublishedDate = new DateTime(1984, 11, 20), ImageUrl = "https://cdn.myanimelist.net/images/anime/1731/96837l.jpg" },
        new Book { Id = 3, Title = "Naruto", Author = "Masashi Kishimoto", Description = "Naruto Uzumaki, a mischievous adolescent ninja, struggles as he searches for recognition from the village.", PublishedDate = new DateTime(1999, 9, 21), ImageUrl = "https://cdn.myanimelist.net/images/manga/3/117681.jpg" },
        new Book { Id = 4, Title = "Chainsaw Man", Author = "Tatsuki Fujimoto", Description = "Denji is a teenage boy living with a Chainsaw Devil named Pochita.", PublishedDate = new DateTime(2018, 12, 3), ImageUrl = "https://cdn.myanimelist.net/images/manga/3/216464.jpg" },
        new Book { Id = 5, Title = "Attack on Titan", Author = "Hajime Isayama", Description = "Humans are nearly exterminated by giant creatures called Titans. Eren Yeager vows to kill them all after they destroy his home.", PublishedDate = new DateTime(2009, 9, 9), ImageUrl = "https://cdn.myanimelist.net/images/manga/2/37846.jpg" },
        new Book { Id = 6, Title = "Jujutsu Kaisen", Author = "Gege Akutami", Description = "A boy swallows a cursed talisman and becomes possessed by the King of Curses.", PublishedDate = new DateTime(2018, 3, 5), ImageUrl = "https://cdn.myanimelist.net/images/anime/1568/128066l.jpg" },
        new Book { Id = 7, Title = "Demon Slayer", Author = "Koyoharu Gotouge", Description = "Tanjiro Kamado becomes a demon slayer to save his sister Nezuko and avenge his family.", PublishedDate = new DateTime(2016, 2, 15), ImageUrl = "https://cdn.myanimelist.net/images/manga/3/179023.jpg" },
        new Book { Id = 8, Title = "Death Note", Author = "Tsugumi Ohba", Description = "A high school student discovers a supernatural notebook that allows him to kill anyone by writing their name in it.", PublishedDate = new DateTime(2003, 12, 1), ImageUrl = "https://cdn.myanimelist.net/images/manga/1/258245.jpg" },
        new Book { Id = 9, Title = "Fullmetal Alchemist", Author = "Hiromu Arakawa", Description = "Two brothers search for the Philosopher's Stone after a failed attempt to bring their mother back to life.", PublishedDate = new DateTime(2001, 7, 12), ImageUrl = "https://cdn.myanimelist.net/images/manga/3/243675.jpg" },
        new Book { Id = 10, Title = "Slam Dunk", Author = "Takehiko Inoue", Description = "Hanamichi Sakuragi is a delinquent and outcast who joins the basketball team to win the heart of a girl.", PublishedDate = new DateTime(1990, 10, 1), ImageUrl = "https://cdn.myanimelist.net/images/manga/2/258749.jpg" }
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
