using TestB_s27776_17c.models.dto_s;

namespace TestB_s27776_17c.repositories;

public interface IBookRepository
{
    Task<BookDTO> GetBook(int id);
    Task<bool> DoesBookExist(int id);
    Task<bool> DoesAuthorExist(int id);
    Task<bool> DoesGenresExist(int id);

    Task<int> DeleteGener(int id);

}