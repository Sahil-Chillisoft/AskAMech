using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
{
    public class UpdateEmployeeActiveStatusUseCase : IUpdateEmployeeActiveStatusUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        public UpdateEmployeeActiveStatusUseCase(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(EditEmployeeRequest request, IPresenter presenter)
        {
            var employee = new Employee
            {
                Id = request.Employee.Id,
                IsActive = request.Employee.IsActive,
                LastModifiedByUserId = UserSecurityManager.UserId,
                DateLastModified = DateTime.Now
            };
            _employeeRepository.UpdateActiveStatus(employee);

            if (request.Employee.IsActive)
                _userRepository.UpdateDateDeletedForEmployeeUser(request.Employee.Id, null);
            else
                _userRepository.UpdateDateDeletedForEmployeeUser(request.Employee.Id, DateTime.Now);
            
            presenter.Success(new EditEmployeeResponse());
        }
    }
}
