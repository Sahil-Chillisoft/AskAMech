using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core
{
    public class Pagination
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
        public int TotalPages { get; set; }
        public int RecordCount { get; set; }
    }
}
