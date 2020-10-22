﻿using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class GetEmployeesUseCase : IGetEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }


        public void Execute(GetEmployeesRequest request, IPresenter presenter)
        {
            var allemployees = _employeeRepository.GetEmployees();

            var response = new GetEmployeesResponse
            {
                AllEmployees = allemployees
               
            };
            presenter.Success(response);
        }
    }
}