using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut9.Exceptions
{
    public class StudentAlreadyExists : Exception
    {
        public StudentAlreadyExists() : base ("Student already exists.") { }
    }
}
