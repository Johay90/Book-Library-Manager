using System.ComponentModel.DataAnnotations;

namespace Book_Library_Manager.Core.Models.DTOs;

public class UpdateProgressDto
{
    [Range(0, 100, ErrorMessage = "Progress must be between 0 and 100.")]
    public float Progress { get; set; }
}
