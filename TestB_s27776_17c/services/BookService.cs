using TestB_s27776_17c.models.dto_s;
using TestB_s27776_17c.repositories;

namespace TestB_s27776_17c.services;

public class BookService(BookRepository repository): IBookService
{
    public Task<bool> DoesBookExist(int id)
    {
        return repository.DoesBookExist(id);
    }

    public Task<int> DeleteGener(int id)
    {
        return repository.DeleteGener(id);
    }

    public Task<BookDTO> GetBook(int id)
    {
        return repository.GetBook(id);
    }
}