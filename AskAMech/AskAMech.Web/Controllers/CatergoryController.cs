using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class CatergoryController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly ICreateCatergoryUseCase _createCatergoryUseCase;
        private readonly IGetCatergoryUsecase _getCatergoryUsecase;
        public CatergoryController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase,ICreateCatergoryUseCase createCatergoryUseCase, IGetCatergoryUsecase getCatergoryUsecase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createCatergoryUseCase = createCatergoryUseCase ?? throw new ArgumentNullException(nameof(createCatergoryUseCase));
            _getCatergoryUsecase = getCatergoryUsecase ?? throw new ArgumentNullException(nameof(getCatergoryUsecase));
        }

        [HttpGet]
        public IActionResult Create()
        {
            _securityManagerUseCase.VerifyUserIsAdmin(_modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return View();

            var model = _modelPresenter.Model as ErrorResponse;
            return RedirectToAction("Index", "Error",
                new
                {
                    message = model?.Message,
                    code = model?.Code
                }); ;
        }

        [HttpPost]
        public IActionResult Create(CreateCatergoryRequest request)
        {
            _createCatergoryUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "Category Successfully Added" });

            var model = _modelPresenter.Model as CreateCatergoryResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult CreateSuccess()
        {
            return PartialView("_CreateSuccess");
        }

        [HttpGet]
        public IActionResult QuestionCatergoryList(CreateCatergoryRequest request)
        {
            _getCatergoryUsecase.Execute(request, _modelPresenter);
          return PartialView("_QuestionCatergoryList", _modelPresenter.Model);
        }
    }
}