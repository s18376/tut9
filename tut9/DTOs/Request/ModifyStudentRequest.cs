using System;
using System.ComponentModel.DataAnnotations;

namespace tut9.DTOs.Request
{
    public class ModifyStudentRequest
    {
        [Required(ErrorMessage = "Provide index number of student")]
        [MaxLength(100)]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }
        [Required(ErrorMessage = "Provide first name of student")]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Provide last name of student")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Provide birth date of student")]
        public DateTime BirthDate { get; set; }
    }
}
