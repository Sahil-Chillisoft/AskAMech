using System;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ISecurityManagerUseCase _securityManagerUseCase;
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IGetEmployeeUseCase _getEmployeeUseCase;
        private readonly IEditUserProfileUseCase _editUserProfileUseCase;
        private readonly IGetUserProfileUseCase _getUserProfileUseCase;
        private readonly IUpdateUserPasswordUseCase _updateUserPasswordUseCase;
        private readonly IGetpdateUserPasswordUseCase _getpdateUserPasswordUseCase;

        public UserController(IModelPresenter modelPresenter,
                              ISecurityManagerUseCase securityManagerUseCase,
                              ICreateUserUseCase createUserUseCase,
                              IGetEmployeeUseCase getEmployeeUseCase,
                              IEditUserProfileUseCase editUserProfileUseCase,
                              IGetUserProfileUseCase getUserProfileUseCase,
                              IUpdateUserPasswordUseCase updateUserPasswordUseCase,
                              IGetpdateUserPasswordUseCase getpdateUserPasswordUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
            _getEmployeeUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _editUserProfileUseCase = editUserProfileUseCase ?? throw new ArgumentNullException(nameof(editUserProfileUseCase));
            _getUserProfileUseCase = getUserProfileUseCase ?? throw new ArgumentNullException(nameof(getUserProfileUseCase));
            _updateUserPasswordUseCase = updateUserPasswordUseCase ?? throw new ArgumentNullException(nameof(updateUserPasswordUseCase));
            _getpdateUserPasswordUseCase= getpdateUserPasswordUseCase ?? throw new ArgumentNullException(nameof(getpdateUserPasswordUseCase));
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
                });
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            _createUserUseCase.Execute(request, _modelPresenter);
            return PartialView("_CreateSuccess");
        }

        [HttpPost]
        public IActionResult GetEmployee(GetEmployeeRequest request)
        {
            _getEmployeeUseCase.Execute(request, _modelPresenter);
            return PartialView("_CreateUser", _modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            _getUserProfileUseCase.Execute(_modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(EditUserProfileRequest request)
        {
            _editUserProfileUseCase.Execute(request, _modelPresenter);
            return Json(!_modelPresenter.HasValidationErrors ?
                new { Success = true } :
                new { Success = false });
        }

        [HttpGet]
        public IActionResult UpdatePassword()
        {
            _getpdateUserPasswordUseCase.Execute(_modelPresenter);
            return PartialView("_UpdatePassword");
        }

        [HttpPost]
        public IActionResult UpdatePassword(UpdateUserPasswordRequest request)
        {
            _updateUserPasswordUseCase.Execute(request, _modelPresenter);
            return Json(!_modelPresenter.HasValidationErrors ?
                new { Success = true } :
                new { Success = false });
        }

        public IActionResult EditSuccess()
        {
            return PartialView("_EditSuccess");
        }
    }
}
