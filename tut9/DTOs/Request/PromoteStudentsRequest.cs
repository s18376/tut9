using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
