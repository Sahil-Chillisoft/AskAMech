using System;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Error;
using AskAMech.Core.Security.Interfaces;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class AnswerController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly IGetUserQuestionAnswersUseCase _getUserQuestionAnswersUseCase;
        private readonly IGetConfirmAcceptedAnswerUseCase _getConfirmAcceptedAnswerUseCase;
        private readonly IUpdateIsAcceptedAnswerUseCase _updateIsAcceptedAnswerUseCase;
        private readonly ICreateAnswerUseCase _createAnswerUseCase;
        private readonly IGetUserAnswerUseCase _getUserAnswerUseCase;
        private readonly IEditAnswerUseCase _editAnswerUseCase;
        private readonly IDeleteAnswerUseCase _deleteAnswerUseCase;
        private readonly IVerifyUserIsAuthenticatedUseCase _verifyUserIsAuthenticatedUseCase;

        public AnswerController(IModelPresenter modelPresenter,
                                IGetUserQuestionAnswersUseCase getUserQuestionAnswersUseCase,
                                IGetConfirmAcceptedAnswerUseCase getConfirmAcceptedAnswerUseCase,
                                IUpdateIsAcceptedAnswerUseCase updateIsAcceptedAnswerUseCase,
                                ICreateAnswerUseCase createAnswerUseCase,
                                IGetUserAnswerUseCase getUserAnswerUseCase,
                                IEditAnswerUseCase editAnswerUseCase,
                                IDeleteAnswerUseCase deleteAnswerUseCase,
                                IVerifyUserIsAuthenticatedUseCase verifyUserIsAuthenticatedUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _getUserQuestionAnswersUseCase = getUserQuestionAnswersUseCase ?? throw new ArgumentNullException(nameof(getUserQuestionAnswersUseCase));
            _getConfirmAcceptedAnswerUseCase = getConfirmAcceptedAnswerUseCase ?? throw new ArgumentNullException(nameof(getConfirmAcceptedAnswerUseCase));
            _updateIsAcceptedAnswerUseCase = updateIsAcceptedAnswerUseCase ?? throw new ArgumentNullException(nameof(updateIsAcceptedAnswerUseCase));
            _createAnswerUseCase = createAnswerUseCase ?? throw new ArgumentNullException(nameof(createAnswerUseCase));
            _getUserAnswerUseCase = getUserAnswerUseCase ?? throw new ArgumentNullException(nameof(getUserAnswerUseCase));
            _editAnswerUseCase = editAnswerUseCase ?? throw new ArgumentNullException(nameof(editAnswerUseCase));
            _deleteAnswerUseCase = deleteAnswerUseCase ?? throw new ArgumentNullException(nameof(deleteAnswerUseCase));
            _verifyUserIsAuthenticatedUseCase = verifyUserIsAuthenticatedUseCase ?? throw new ArgumentNullException(nameof(verifyUserIsAuthenticatedUseCase));
        }

        [HttpGet]
        public IActionResult MyAnswers()
        {
            _verifyUserIsAuthenticatedUseCase.IsAuthenticated(_modelPresenter);
            if (_modelPresenter.HasValidationErrors)
            {
                var model = _modelPresenter.Model as ErrorResponse;
                return RedirectToAction("Index", "Error",
                    new
                    {
                        message = model?.Message,
                        code = model?.Code
                    });
            }
            _getUserQuestionAnswersUseCase.Execute(new GetUserQuestionAnswersRequest(), _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult MyAnswers(GetUserQuestionAnswersRequest request)
        {
            _getUserQuestionAnswersUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult ConfirmAcceptedAnswer(GetConfirmAcceptedAnswerRequest request)
        {
            _getConfirmAcceptedAnswerUseCase.Execute(request, _modelPresenter);
            return PartialView("_ConfirmAcceptedAnswer", _modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult UpdateAcceptedAnswer(UpdateIsAcceptedAnswerRequest request)
        {
            _updateIsAcceptedAnswerUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public IActionResult Create(CreateAnswerRequest request)
        {
            _createAnswerUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult Edit(GetUserAnswerRequest request)
        {
            _getUserAnswerUseCase.Execute(request, _modelPresenter);
            return PartialView("_Edit", _modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(EditAnswerRequest request)
        {
            _editAnswerUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return PartialView("_Delete");
        }

        [HttpPost]
        public IActionResult Delete(DeleteAnswerRequest request)
        {
            _deleteAnswerUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult Error()
        {
            return PartialView("_Error");
        }
    }
}
