using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Core.UseCases
{
    public class UserDashboardUseCase : IUserDashboardUseCase
    {
        private readonly IUserDashboardRepository _userDashboardRepository;

        public UserDashboardUseCase(IUserDashboardRepository userDashboardRepository)
        {
            _userDashboardRepository = userDashboardRepository ?? throw new ArgumentNullException(nameof(userDashboardRepository));
        }

        public void Execute(UserDashboardRequest request, IPresenter presenter)
        {
            if (UserSecurityManager.IsAuthenticated &&
                (UserSecurityManager.UserRoleId == (int)UserRole.Mechanic ||
                 UserSecurityManager.UserRoleId == (int)UserRole.GeneralUser))
            {
                var userDashboard = _userDashboardRepository.GetKeyPerformanceIndicators(request.UserId);
                var response = new UserDashboardResponse
                {
                    QuestionCount = userDashboard.QuestionCount,
                    AnswerCount = userDashboard.AnswerCount
                };
                presenter.Success(response);
            }
            else
            {
                presenter.Error(true);
            }
        }
    }
}
