using Assignment3WebAPI.Interfaces;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Services
{
    public class BookService:IBookService
    {
        private readonly AppDbContext _context;
        private readonly List<Book> _books = new();

        public BookService(AppDbContext context) 
        { 
            _context = context;
        }

        // Get All
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        // GET Book By Id
        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        //Add books
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        // Update
        public void UpdateBook(int id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.PublicationYear = updatedBook.PublicationYear;
                book.ISBN = updatedBook.ISBN;
            }
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
        }

        // Delete
        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
