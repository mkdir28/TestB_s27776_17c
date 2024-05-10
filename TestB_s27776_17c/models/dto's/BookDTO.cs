using System.ComponentModel.DataAnnotations;

namespace TestB_s27776_17c.models.dto_s;

public class BookDTO
{
    [Required]
    public int PK { get; set; }
    [Required]
    public string Title { get; set; }
}

public class GenresDTO
{
    [Required]
    public int PK { get; set; }
    [Required]
    public string nam { get; set; }
}

public class PublishingHousesDTO
{
    [Required]
    public int PK { get; set; }
    [Required]
    public string name { get; set; }
    [Required]
    public string? owner_first_nam { get; set; }
    [Required]
    public string owner_last_nam { get; set; }

}


public class AuthorsDTO
{
    [Required]
    public int PK { get; set; }
    [Required]
    public string? first_na { get; set; }
    [Required]
    public string last_na { get; set; }

}

public class BookEditionsDTO
{
    [Required]
    public int PK { get; set; }
    [Required]
    public PublishingHousesDTO PKPublishHouse { get; set; }
    [Required]
    public BookDTO PKBook { get; set; }
    [Required]
    public string edition_title { get; set; }
    [Required]
    public string release_date { get; set; }
}