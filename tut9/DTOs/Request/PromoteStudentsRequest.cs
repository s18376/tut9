using System.ComponentModel.DataAnnotations;

namespace tut9.DTOs.Request
{
    public class PromoteStudentsRequest
    {
        [Required(ErrorMessage = "Provide name of study")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide semester")]
        public int Semester { get; set; }
    }
}
