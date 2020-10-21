using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Core.UseCases.Requests
{
    public class GetQuestionsRequest
    {
        public string Search { get; set; }
        public int CategoryId { get; set; }
        public bool IsPagingRequest { get; set; }
        public Pagination Pagination { get; set; }
    }
}
