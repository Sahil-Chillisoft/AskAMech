namespace AskAMech.Core.Employees.Requests
{
    public class GetEmployeesRequest
    {
        public string Search { get; set; }
        public Pagination Pagination { get; set; }
    }
}
