using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Error;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Security;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly IGetQuestionsUseCase _getQuestionsUseCase;
        private readonly ICreateQuestionUseCase _createQuestionUseCase;
        private readonly IGetCreateQuestionUseCase _getCreateQuestionUseCase;
        private readonly IGetQuestionViewUseCase _getQuestionViewUseCase;
        private readonly IEditQuestionUseCase _editQuestionUseCase;
        private readonly IGetEditQuestionUseCase _getEditQuestionUseCase;
        private readonly IGetUserQuestions _getUserQuestions;
        private readonly IDeleteQuestionUseCase _deleteQuestionUseCase;

        public QuestionController(IModelPresenter modelPresenter,
                                  ISecurityManagerUseCase securityManagerUseCase,
                                  IGetQuestionsUseCase getQuestionsUseCase,
                                  ICreateQuestionUseCase createQuestionUseCase,
                                  IGetCreateQuestionUseCase getCreateQuestionUseCase,
                                  IGetQuestionViewUseCase getQuestionViewUseCase,
                                  IEditQuestionUseCase editQuestionUseCase,
                                  IGetEditQuestionUseCase getEditQuestionUseCase,
                                  IGetUserQuestions getUserQuestions,
                                  IDeleteQuestionUseCase deleteQuestionUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _getQuestionsUseCase = getQuestionsUseCase ?? throw new ArgumentNullException(nameof(getQuestionsUseCase));
            _createQuestionUseCase = createQuestionUseCase ?? throw new ArgumentNullException(nameof(createQuestionUseCase));
            _getCreateQuestionUseCase = getCreateQuestionUseCase ?? throw new ArgumentNullException(nameof(getCreateQuestionUseCase));
            _getQuestionViewUseCase = getQuestionViewUseCase ?? throw new ArgumentNullException(nameof(getQuestionViewUseCase));
            _editQuestionUseCase = editQuestionUseCase ?? throw new ArgumentNullException(nameof(editQuestionUseCase));
            _getEditQuestionUseCase = getEditQuestionUseCase ?? throw new ArgumentNullException(nameof(getEditQuestionUseCase));
            _getUserQuestions = getUserQuestions ?? throw new ArgumentNullException(nameof(getUserQuestions));
            _deleteQuestionUseCase = deleteQuestionUseCase ?? throw new ArgumentNullException(nameof(deleteQuestionUseCase));
        }

        [HttpGet]
        public IActionResult Index()
        {
            _getQuestionsUseCase.Execute(new GetQuestionsRequest(), _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Index(GetQuestionsRequest request)
        {
            ModelState.Clear();
            _getQuestionsUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _securityManagerUseCase.VerifyUserIsMechanicOrGeneralUser(_modelPresenter);
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

            _getCreateQuestionUseCase.Execute(_modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Create(CreateQuestionRequest request)
        {
            _createQuestionUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }

        [HttpGet]
        public IActionResult ViewQuestion(int id)
        {
            var request = new GetViewQuestionRequest { Id = id };
            _getQuestionViewUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = new GetEditQuestionRequest { Id = id };
            _getEditQuestionUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(EditQuestionRequest request)
        {
            _editQuestionUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult EditSuccess()
        {
            return PartialView("_EditSuccess");
        }

        [HttpGet]
        public IActionResult MyQuestions()
        {
            var request = new GetUserQuestionsRequest
            {
                UserId = UserSecurityManager.UserId
            };
            _getUserQuestions.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult MyQuestions(GetUserQuestionsRequest request)
        {
            request.UserId = UserSecurityManager.UserId;
            _getUserQuestions.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return PartialView("_Delete");
        }

        [HttpPost]
        public IActionResult Delete(DeleteQuestionRequest request)
        {
            _deleteQuestionUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }
    }
}
