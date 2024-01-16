using System;
using AskAMech.Core.Categories.Interfaces;
using AskAMech.Core.Categories.Requests;
using AskAMech.Core.Categories.Responses;
using AskAMech.Core.Error;
using AskAMech.Core.Security.Interfaces;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ICreateCategoryUseCase _createCategoryUseCase;
        private readonly IGetCategoryUseCase _getCategoryUseCase;
        private readonly IVerifyUserRoleUseCase _verifyUserRoleUseCase;

        public CategoryController(IModelPresenter modelPresenter,
                                  ICreateCategoryUseCase createCategoryUseCase,
                                  IGetCategoryUseCase getCategoryUseCase,
                                  IVerifyUserRoleUseCase verifyUserRoleUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _createCategoryUseCase = createCategoryUseCase ?? throw new ArgumentNullException(nameof(createCategoryUseCase));
            _getCategoryUseCase = getCategoryUseCase ?? throw new ArgumentNullException(nameof(getCategoryUseCase));
            _verifyUserRoleUseCase = verifyUserRoleUseCase ?? throw new ArgumentNullException(nameof(verifyUserRoleUseCase));
        }

        [HttpGet]
        public IActionResult Create()
        {
            _verifyUserRoleUseCase.IsAdmin(_modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return View();

            var model = _modelPresenter.Model as ErrorResponse;
            return RedirectToAction("Index", "Error",
                new
                {
                    message = model?.Message,
                    code = model?.Code
                });
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryRequest request)
        {
            _createCategoryUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true });

            var model = _modelPresenter.Model as CreateCategoryResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }

        [HttpGet]
        public IActionResult QuestionCategoryList(CreateCategoryRequest request)
        {
            _getCategoryUseCase.Execute(request, _modelPresenter);
            return PartialView("_QuestionCategoryList", _modelPresenter.Model);
        }
    }
}