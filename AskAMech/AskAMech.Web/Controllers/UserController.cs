﻿using System;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Web.Presenters;
using Microsoft.AspNetCore.Mvc;
using AskAMech.Core.Domain;

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

        public UserController(IModelPresenter modelPresenter,
                              ISecurityManagerUseCase securityManagerUseCase,
                              ICreateUserUseCase createUserUseCase,
                              IGetEmployeeUseCase getEmployeeUseCase,
                              IEditUserProfileUseCase editUserProfileUseCase,
                              IGetUserProfileUseCase getUserProfileUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
            _getEmployeeUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _editUserProfileUseCase = editUserProfileUseCase ?? throw new ArgumentNullException(nameof(editUserProfileUseCase));
            _getUserProfileUseCase = getUserProfileUseCase ?? throw new ArgumentNullException(nameof(getUserProfileUseCase));

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
            var request = new EditUserProfileRequest()
            {
                viewUser = new ViewUserInfo()
                {
                    userProfile = new UserProfile()
                    {
                        UserId = UserSecurityManager.UserId
                    },
                }
            };

            _getUserProfileUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(ViewUserInfo? users)
        {
            var request = new EditUserProfileRequest()
            {
                viewUser = new ViewUserInfo()
                {
                    userProfile =new UserProfile()// users.userProfile,
                    {
                        UserId = users.userProfile.UserId,
                        Username = users.userProfile.Username,
                        About = users.userProfile.About,
                        DateLastModified = users.userProfile.DateLastModified
                    }

                    //user = users.user
                      //new User() //{//    Password=user.
                    //}
                }

            };
            //this is a check statement
            //if (users.user.Password.Equals(null))
            //{
            //    _editUserProfileUseCase.Execute(request, _modelPresenter);
            //}
            //else 
            //{
                _editUserProfileUseCase.Execute(request, _modelPresenter);
                //here will put another method for updating password

           // }

            if (!_modelPresenter.HasValidationErrors)
                return Json(new { Success = true, Message = "user profile has been successfully updated" });

            var model = _modelPresenter.Model as EditUserProfileResponse;
            return Json(new { Sucess = false, Message = model?.ErrorMessage });
        }

        public IActionResult EditSuccess()
        {
            return PartialView("_EditSuccess");
        }
    }
}
