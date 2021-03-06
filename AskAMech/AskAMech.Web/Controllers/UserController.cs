﻿using System;
using AskAMech.Core.Employees.Interfaces;
using AskAMech.Core.Employees.Requests;
using AskAMech.Core.Error;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Requests;
using AskAMech.Core.Security.Interfaces;
using AskAMech.Core.Users.Interfaces;
using AskAMech.Core.Users.Requests;
using AskAMech.Core.Users.Responses;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace AskAMech.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IModelPresenter _modelPresenter;
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IGetEmployeeForUserUseCase _getEmployeeForUserUseCase;
        private readonly IEditUserProfileUseCase _editUserProfileUseCase;
        private readonly IGetUserProfileUseCase _getUserProfileUseCase;
        private readonly IUpdateUserPasswordUseCase _updateUserPasswordUseCase;
        private readonly IGetEmployeeUseCase _getEmployeeUseCase;
        private readonly IGetViewUserProfile _getViewUserProfile;
        private readonly IDeleteUserAccountUseCase _deleteUserAccountUseCase;
        private readonly IGetUserQuestions _getUserQuestions;
        private readonly IVerifyUserIsAuthenticatedUseCase _verifyUserIsAuthenticatedUseCase;
        private readonly IVerifyUserRoleUseCase _verifyUserRoleUseCase;

        public UserController(IModelPresenter modelPresenter,
                              ICreateUserUseCase createUserUseCase,
                              IGetEmployeeForUserUseCase getEmployeeForUserUseCase,
                              IEditUserProfileUseCase editUserProfileUseCase,
                              IGetUserProfileUseCase getUserProfileUseCase,
                              IUpdateUserPasswordUseCase updateUserPasswordUseCase,
                              IGetEmployeeUseCase getEmployeeUseCase,
                              IGetViewUserProfile getViewUserProfile,
                              IDeleteUserAccountUseCase deleteUserAccountUseCase,
                              IGetUserQuestions getUserQuestions, 
                              IVerifyUserIsAuthenticatedUseCase verifyUserIsAuthenticatedUseCase, 
                              IVerifyUserRoleUseCase verifyUserRoleUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
            _getEmployeeForUserUseCase = getEmployeeForUserUseCase ?? throw new ArgumentNullException(nameof(getEmployeeForUserUseCase));
            _editUserProfileUseCase = editUserProfileUseCase ?? throw new ArgumentNullException(nameof(editUserProfileUseCase));
            _getUserProfileUseCase = getUserProfileUseCase ?? throw new ArgumentNullException(nameof(getUserProfileUseCase));
            _updateUserPasswordUseCase = updateUserPasswordUseCase ?? throw new ArgumentNullException(nameof(updateUserPasswordUseCase));
            _getEmployeeUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _getViewUserProfile = getViewUserProfile ?? throw new ArgumentNullException(nameof(getViewUserProfile));
            _deleteUserAccountUseCase = deleteUserAccountUseCase ?? throw new ArgumentNullException(nameof(deleteUserAccountUseCase));
            _getUserQuestions = getUserQuestions ?? throw new ArgumentNullException(nameof(getUserQuestions));
            _verifyUserIsAuthenticatedUseCase = verifyUserIsAuthenticatedUseCase;
            _verifyUserRoleUseCase = verifyUserRoleUseCase;
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
        public IActionResult Create(CreateUserRequest request)
        {
            _createUserUseCase.Execute(request, _modelPresenter);
            return PartialView("_CreateSuccess");
        }

        [HttpPost]
        public IActionResult GetEmployee(GetEmployeeForUserRequest forUserRequest)
        {
            _getEmployeeForUserUseCase.Execute(forUserRequest, _modelPresenter);
            return PartialView("_CreateUser", _modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Edit()
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

            _getUserProfileUseCase.Execute(_modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(EditUserProfileRequest request)
        {
            _editUserProfileUseCase.Execute(request, _modelPresenter);

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true });

            var model = _modelPresenter.Model as EditUserProfileResponse;
            return Json(new { Success = false, Message = model?.ErrorMessage });
        }

        [HttpGet]
        public IActionResult UpdatePassword()
        {
            return PartialView("_UpdatePassword");
        }

        [HttpPost]
        public IActionResult UpdatePassword(UpdateUserPasswordRequest request)
        {
            _updateUserPasswordUseCase.Execute(request, _modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult EditSuccess()
        {
            return PartialView("_EditSuccess");
        }

        [HttpGet]
        public IActionResult EmployeeDetails(int employeeId)
        {
            var request = new GetEmployeeRequest { Id = employeeId };
            _getEmployeeUseCase.Execute(request, _modelPresenter);
            return PartialView("_EmployeeDetails", _modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult ViewUserProfile(int id)
        {
            _verifyUserIsAuthenticatedUseCase.IsAuthenticated(_modelPresenter);
            if (_modelPresenter.HasValidationErrors)
            {
                var model = _modelPresenter.Model as ErrorResponse;
                model.Message += " - Only logged in users can view the profiles of other users";
                return RedirectToAction("Index", "Error",
                    new
                    {
                        message = model?.Message,
                        code = model?.Code
                    });
            }

            var request = new GetViewUserProfileRequest { Id = id };
            _getViewUserProfile.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return PartialView("_DeleteAccount");
        }

        [HttpPost]
        public IActionResult DeleteAccount()
        {
            _deleteUserAccountUseCase.Execute(_modelPresenter);
            return Json(new { Success = true });
        }

        [HttpGet]
        public IActionResult DeleteSuccess()
        {
            return PartialView("_DeleteSuccess");
        }

        [HttpPost]
        public IActionResult UserQuestions(GetUserQuestionsRequest request)
        {
            _getUserQuestions.Execute(request, _modelPresenter);
            return PartialView("_UserQuestions", _modelPresenter.Model);
        }
    }
}
