using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core
{
    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; }
        public int Offset { get; set; }
        public int Next { get; set; }
    }
}
