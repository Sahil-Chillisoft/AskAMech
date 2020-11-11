using System;
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
        private readonly IGetUserPasswordUseCase _getUserPasswordUseCase;

        public UserController(IModelPresenter modelPresenter,
                              ISecurityManagerUseCase securityManagerUseCase,
                              ICreateUserUseCase createUserUseCase,
                              IGetEmployeeUseCase getEmployeeUseCase,
                              IEditUserProfileUseCase editUserProfileUseCase,
                              IGetUserProfileUseCase getUserProfileUseCase,
                              IGetUserPasswordUseCase getUserPasswordUseCase)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
            _getEmployeeUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _editUserProfileUseCase = editUserProfileUseCase ?? throw new ArgumentNullException(nameof(editUserProfileUseCase));
            _getUserProfileUseCase = getUserProfileUseCase ?? throw new ArgumentNullException(nameof(getUserProfileUseCase));
            _getUserPasswordUseCase = getUserPasswordUseCase ?? throw new ArgumentNullException(nameof(getUserPasswordUseCase));

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
                //viewUser = new ViewUserInfo()
                //{
                    userProfile = new UserProfile()
                    {
                        UserId = UserSecurityManager.UserId
                    },
                //}
            };

            _getUserProfileUseCase.Execute(request, _modelPresenter);
            _getUserPasswordUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(UserProfile? users)
        {
            var request = new EditUserProfileRequest()
            {
                //viewUser = new ViewUserInfo()
                //{
                    userProfile = new UserProfile()
                    {
                        UserId = users.UserId,
                        Username = users.Username,
                        About = users.About,
                        DateLastModified = users.DateLastModified
                    }

                    //user = users.user
                    //new User() //{//    Password=user.
                    //}
                //}

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
