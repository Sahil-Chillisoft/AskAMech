namespace AskAMech.Core
{
    public class Pagination
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
        public int TotalPages { get; set; }
        public int RecordCount { get; set; }
        public bool IsPagingRequest { get; set; }
    }

    public enum PageSize
    {
        Small = 5,
        Medium = 10,
        Large = 20,
        ExtraLarge = 50
    }
}
