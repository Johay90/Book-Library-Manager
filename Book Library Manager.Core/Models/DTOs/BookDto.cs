namespace Book_Library_Manager.Core.Models.DTOs;

public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public string Genre { get; set; }
    public string BorrowedBy { get; set; }
    public DateTime? BorrowDate { get; set; }
    public float ReadingProgress { get; set; }
}
