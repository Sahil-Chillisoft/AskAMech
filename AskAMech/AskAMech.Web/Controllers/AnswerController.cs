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
        private readonly IGetConfirmAcceptedAnswerUseCase _getConfirmAcceptedAnswerUseCase;

        public AnswerController(IModelPresenter modelPresenter,
                                ISecurityManagerUseCase securityManagerUseCase,
                                IGetUserQuestionAnswersUseCase getUserQuestionAnswersUseCase, 
                                IGetConfirmAcceptedAnswerUseCase getConfirmAcceptedAnswerUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _getUserQuestionAnswersUseCase = getUserQuestionAnswersUseCase ?? throw new ArgumentNullException(nameof(getUserQuestionAnswersUseCase));
            _getConfirmAcceptedAnswerUseCase = getConfirmAcceptedAnswerUseCase ?? throw new ArgumentNullException(nameof(getConfirmAcceptedAnswerUseCase));
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

        [HttpGet]
        public IActionResult ConfirmAcceptedAnswer(GetConfirmAcceptedAnswerRequest request)
        {
            _getConfirmAcceptedAnswerUseCase.Execute(request, _modelPresenter);
            return PartialView("_ConfirmAcceptedAnswer", _modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult UpdateAcceptedAnswer()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult PostAnswer()
        {
            throw new NotImplementedException();
        }

    }
}
