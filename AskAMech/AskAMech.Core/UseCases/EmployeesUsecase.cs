using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;


namespace AskAMech.Core.UseCases
{
   public class EmployeesUsecase : IEmployeesUsecase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesUsecase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));

        }

        public void Execute(EmployeeRequest requests, IPresenter presenter)
        {

        }
        private int CreateNewEmployee(EmployeeRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                Email = request.Email,
                IsRegisterdUser = request.IsRegisterdUser,
                CreatedByUserId = (int)UserRole.Admin,
                DateCreated = DateTime.Now, 
                LastModifiedByUserId = (int)UserRole.Admin,
                DateLastModified = DateTime.Now
            };

            return _employeeRepository.CreateNewEmployee(employee);
        }
    }
}
