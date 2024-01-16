using System;
using AskAMech.Core.Dashboard.Interfaces;
using AskAMech.Core.Dashboard.Requests;
using AskAMech.Core.Dashboard.Responses;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.Dashboard.UseCases
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
            var userDashboard = _userDashboardRepository.GetKeyPerformanceIndicators(request.UserId);
            var response = new UserDashboardResponse
            {
                QuestionCount = userDashboard.QuestionCount,
                AnswerCount = userDashboard.AnswerCount
            };
            presenter.Success(response);
        }
    }
}
