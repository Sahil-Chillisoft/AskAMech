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
        public void Execute(EmployeeRequest request, IPresenter presenter)
        {
            var response = new EmployeeResponse();
            var isExistingEmail = _employeeRepository.IsExistingEmloyeeEmail(request.Email);
            if(!isExistingEmail)
            {
                 CreateNewEmployee(request);
                presenter.Success(response);
            }
            else
            {
                response.Email = request.Email;
                response.FirstName = request.FirstName;
                response.LastName = request.LastName;
                response.IdNumber = request.IdNumber;
                response.LastName = request.LastName;
                response.RegisterErrorMessage = "Error: The email you entered already exists";
                presenter.Error(response, true);

            }
        }
        private void CreateNewEmployee(EmployeeRequest request)
        {
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                IdNumber = request.IdNumber,
                Email = request.Email,
                CreatedByUserId = (int)UserRole.Admin,
                DateCreated = DateTime.Now, 
                LastModifiedByUserId = (int)UserRole.Admin,
                DateLastModified = DateTime.Now
            };
        }
    }
}
