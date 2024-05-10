using TestB_s27776_17c.models.dto_s;

namespace TestB_s27776_17c.services;

public interface IBookService
{
    Task<bool> DoesBookExist(int id);
    Task<int> DeleteGener(int id);
    Task<BookDTO> GetBook(int id);


}