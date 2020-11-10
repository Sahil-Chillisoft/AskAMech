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
        private readonly IGetQuestionCategoryUseCase _getQuestionCategoryUseCase;

        public QuestionController(IModelPresenter modelPresenter, 
                                  ISecurityManagerUseCase securityManagerUseCase, 
                                  IGetQuestionsUseCase getQuestionsUseCase,
                                  ICreateQuestionUseCase createQuestionUseCase,
                                  IGetQuestionCategoryUseCase getQuestionCategoryUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _getQuestionsUseCase = getQuestionsUseCase ?? throw new ArgumentNullException(nameof(getQuestionsUseCase));
            _createQuestionUseCase = createQuestionUseCase ?? throw new ArgumentNullException(nameof(createQuestionUseCase));
            _getQuestionCategoryUseCase = getQuestionCategoryUseCase ?? throw new ArgumentNullException(nameof(getQuestionCategoryUseCase));

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
        public IActionResult Create(GetQuestionsRequest request)
        {
            _securityManagerUseCase.VerifyUserIsMechanicOrGeneralUser(_modelPresenter);
            _getQuestionCategoryUseCase.Execute(request, _modelPresenter);

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateQuestionRequest request)
        {
            _createQuestionUseCase.Execute(request, _modelPresenter);

                return Json(new { Success = true, Message = "A question is Successfully submitted" });
        }
        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }
    }
}
