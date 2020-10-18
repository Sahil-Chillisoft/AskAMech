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
    public class EmployeeListUsecase : IEmployeeListUsecase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeListUsecase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }


        public void Execute(GetAllEmployeesRequest request, IPresenter presenter)
        {
            var allemployees = _employeeRepository.getAllEmployees();

            var response = new GetAllEmployeesResponse
            {
                AllEmployees = allemployees
               
            };
            presenter.Success(response);
        }
    }
}
