namespace Book_Library_Manager.Core.Models.DTOs;

public class CreateBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public string Genre { get; set; }
}
