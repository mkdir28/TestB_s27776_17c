using Microsoft.Data.SqlClient;
using TestB_s27776_17c.models.dto_s;

namespace TestB_s27776_17c.repositories;

public class BookRepository(IConfiguration configuration): IBookRepository
{
    public async Task<bool> DoesBookExist(int id)
    {
        var query = "Select 1 From [BookDTO] where id=@id";
        //open connection
        await using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Docker"));
        await connection.OpenAsync();
        
        //create command
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@id", id);

        var result = await command.ExecuteScalarAsync();

        return result is not null;
    }

    public async Task<bool> DoesAuthorExist(int id)
    {
        var query = "Select 1 From [AuthorsDTO] where id=@id";
        //open connection
        await using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Docker"));
        await connection.OpenAsync();
        
        //create command
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@id", id);

        var result = await command.ExecuteScalarAsync();

        return result is not null;
    }

    public async Task<bool> DoesGenresExist(int id)
    {
        var query = "Select 1 From [GenresDTO] where id=@id";
        //open connection
        await using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Docker"));
        await connection.OpenAsync();
        
        //create command
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        
        command.CommandText = query;
        command.Parameters.AddWithValue("@id", id);

        var result = await command.ExecuteScalarAsync();

        return result is not null;
    }

    public async Task<BookDTO> GetBook(int id)
    {
        var query = "Select BookDTO.PKBook as id, BookDTO.Title as title, authors.first_name as firstName," +
                    "authors.last_name as lastName, GenresDTO.name From [BookDTO] book JOIN authors a on a.PKAuthor = book.PKAuthor " +
                    "Join GenresDTO genres on genres.PKGenre = book.PKGenre WHERE book.BookDTO = @Id"
        //open connection
        await using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Docker"));
        await connection.OpenAsync();
        
        //create command
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@Id", id);
        
        await connection.OpenAsync();

        var reader = await command.ExecuteReaderAsync();
        

        var idBook = reader.GetOrdinal("id");
        var booktitle = reader.GetOrdinal("title");
        var first_name = reader.GetOrdinal("firstName");
        var last_name = reader.GetOrdinal("lastName");
        var nameGener = reader.GetOrdinal("");
        
        BookDTO book = null;
        while (await reader.ReadAsync())
        {
            if (book is not null)
            {
                book.authors.Add(new AuthorsDTO()
                {
                    
                });
            } else if (book is not null)
            {
                
            }
            else
            {
                book = new BookDTO()
                {
                    
                }
            }
            

        }
    }


    public async Task<int> DeleteGener(int id)
    {
        var query = "DELETE FROM GenresDTO WHERE PKGenre = @PKGenre";
        //open connection
        await using SqlConnection connection = new SqlConnection(configuration.GetConnectionString("Docker"));
        await connection.OpenAsync();
        
        //create command
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@PKGenre", id);
        
        var result = command.ExecuteNonQuery();

        return result;
    }
}