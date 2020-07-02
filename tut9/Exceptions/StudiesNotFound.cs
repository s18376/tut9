using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut9.Exceptions
{
    public class StudiesNotFound : Exception
    {
        public StudiesNotFound() : base("Studies not found.") { }
    }
}
