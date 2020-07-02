using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut9.Exceptions
{
    public class StudentNotFound : Exception
    {
        public StudentNotFound() : base("Student not found.") { }
    }
}
