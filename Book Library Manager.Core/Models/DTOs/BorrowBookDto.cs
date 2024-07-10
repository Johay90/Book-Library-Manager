using System.ComponentModel.DataAnnotations;

namespace Book_Library_Manager.Core.Models.DTOs;

public class BorrowBookDto
{
    [Required]
    public string Borrower { get; set; }
}
