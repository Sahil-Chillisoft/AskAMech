using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly IGetQuestionsUseCase _getQuestionsUseCase;

        public QuestionController(IModelPresenter modelPresenter, ISecurityManagerUseCase securityManagerUseCase, IGetQuestionsUseCase getQuestionsUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _getQuestionsUseCase = getQuestionsUseCase ?? throw new ArgumentNullException(nameof(getQuestionsUseCase));
        }

        [HttpGet]
        public IActionResult Index(GetQuestionsRequest request)
        {
            _getQuestionsUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }
    }
}
