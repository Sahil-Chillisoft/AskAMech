using System;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;

namespace AskAMech.Web.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly IGetUserQuestionAnswersUseCase _getUserQuestionAnswersUseCase;
        
        public AnswerController(IModelPresenter modelPresenter,
                                  ISecurityManagerUseCase securityManagerUseCase,
                                IGetUserQuestionAnswersUseCase getUserQuestionAnswersUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _getUserQuestionAnswersUseCase = getUserQuestionAnswersUseCase ?? throw new ArgumentNullException(nameof(getUserQuestionAnswersUseCase));

        }

        [HttpGet]
        public IActionResult MyAnswers()
        {
            var request = new GetUserQuestionAnswersRequest
            {
                questionAnswers = new ViewUserQuestionAnswers
                {
                    AskedBy = UserSecurityManager.Username
                }
            };
            _getUserQuestionAnswersUseCase.Execute(request, _modelPresenter);
            return View("MyAnswers", _modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult MyAnswers(GetUserQuestionAnswersRequest request)
        {
            request.questionAnswers.AskedBy = UserSecurityManager.Username;
            _getUserQuestionAnswersUseCase.Execute(request, _modelPresenter);
            return View("MyAnswers", _modelPresenter.Model);
        }

    }
}
