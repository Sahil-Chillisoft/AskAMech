using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Employees.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Employees.UseCases
{
    public class EditEmployeeUserPasswordUseCase : IEditEmployeeUserPassword
    {
        private readonly IUserRepository _userRepository;

        public EditEmployeeUserPasswordUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(EditEmployeeUserPasswordRequest request, IPresenter presenter)
        {
            var response = new EditEmployeeUserPasswordResponse();
            var hasLinkedUserAccount = _userRepository.IsExitingEmployeeUser(request.EmployeeId);
            if (hasLinkedUserAccount)
            {
                var userDetails = _userRepository.GetUserByEmployeeId(request.EmployeeId);
                var user = new User
                {
                    Id = userDetails.Id,
                    Password = "Password@1",
                    DateLastModified = DateTime.Now
                };
                _userRepository.UpdatePassword(user);
                response.SuccessMessage = "Password has been successfully updated";
                presenter.Success(response);
            }
            else
            {
                response.ErrorMessage = "Error: No linked user account could be found for the employee";
                presenter.Error(response, true);
            }
        }
    }
}
