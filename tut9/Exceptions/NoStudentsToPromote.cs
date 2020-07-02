using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut9.Exceptions
{
    public class NoStudentsToPromote : Exception
    {
        public NoStudentsToPromote() : base ("There are no students to promote.") { }
    }
}
