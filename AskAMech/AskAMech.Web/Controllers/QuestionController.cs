using System;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Core.UseCases.Responses;

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

        public QuestionController(IModelPresenter modelPresenter,
                                  ISecurityManagerUseCase securityManagerUseCase,
                                  IGetQuestionsUseCase getQuestionsUseCase,
                                  ICreateQuestionUseCase createQuestionUseCase,
                                  IGetCreateQuestionUseCase getCreateQuestionUseCase,
                                  IGetQuestionViewUseCase getQuestionViewUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _getQuestionsUseCase = getQuestionsUseCase ?? throw new ArgumentNullException(nameof(getQuestionsUseCase));
            _createQuestionUseCase = createQuestionUseCase ?? throw new ArgumentNullException(nameof(createQuestionUseCase));
            _getCreateQuestionUseCase = getCreateQuestionUseCase ?? throw new ArgumentNullException(nameof(getCreateQuestionUseCase));
            _getQuestionViewUseCase = getQuestionViewUseCase ?? throw new ArgumentNullException(nameof(getQuestionViewUseCase));
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

            _getCreateQuestionUseCase.Execute(new CreateQuestionRequest(), _modelPresenter);
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
    }
}
