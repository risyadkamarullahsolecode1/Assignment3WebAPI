using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(int id, Book updatedBook);
        void DeleteBook(int id);
    }
}
