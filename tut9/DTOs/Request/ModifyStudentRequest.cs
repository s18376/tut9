using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tut9.DTOs.Request
{
    public class ModifyStudentRequest
    {
        [Required(ErrorMessage = "Provide index number of student")]
        [RegularExpression("^s[0-9]+$")]
        public string IndexNumber { get; set; }
        [Required(ErrorMessage = "Provide first name of student")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Provide last name of student")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Provide birth date of student")]
        public DateTime BirthDate { get; set; }
    }
}
