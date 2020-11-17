using System;
using AskAMech.Core.Domain;
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
        private readonly IGetEmployeeForUserUseCase _getEmployeeForUserUseCase;
        private readonly IEditUserProfileUseCase _editUserProfileUseCase;
        private readonly IGetUserProfileUseCase _getUserProfileUseCase;
        private readonly IUpdateUserPasswordUseCase _updateUserPasswordUseCase;
        private readonly IGetEmployeeUseCase _getEmployeeUseCase;
        private readonly IGetViewUserProfile _getViewUserProfile;
        private readonly IDeleteuserAccountUseCase _deleteUserAccountUseCase;
        private readonly IGetUserQuestions _getUserQuestions;

        public UserController(IModelPresenter modelPresenter,
                              ISecurityManagerUseCase securityManagerUseCase,
                              ICreateUserUseCase createUserUseCase,
                              IGetEmployeeForUserUseCase getEmployeeForUserUseCase,
                              IEditUserProfileUseCase editUserProfileUseCase,
                              IGetUserProfileUseCase getUserProfileUseCase,
                              IUpdateUserPasswordUseCase updateUserPasswordUseCase,
                              IGetEmployeeUseCase getEmployeeUseCase,
                              IGetViewUserProfile getViewUserProfile,
                              IDeleteuserAccountUseCase deleteUserAccountUseCase,
                              IGetUserQuestions getUserQuestions)
        {
            _modelPresenter = modelPresenter ?? throw new ArgumentNullException(nameof(modelPresenter));
            _securityManagerUseCase = securityManagerUseCase ?? throw new ArgumentNullException(nameof(securityManagerUseCase));
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
            _getEmployeeForUserUseCase = getEmployeeForUserUseCase ?? throw new ArgumentNullException(nameof(getEmployeeForUserUseCase));
            _editUserProfileUseCase = editUserProfileUseCase ?? throw new ArgumentNullException(nameof(editUserProfileUseCase));
            _getUserProfileUseCase = getUserProfileUseCase ?? throw new ArgumentNullException(nameof(getUserProfileUseCase));
            _updateUserPasswordUseCase = updateUserPasswordUseCase ?? throw new ArgumentNullException(nameof(updateUserPasswordUseCase));
            _getEmployeeUseCase = getEmployeeUseCase ?? throw new ArgumentNullException(nameof(getEmployeeUseCase));
            _getViewUserProfile = getViewUserProfile ?? throw new ArgumentNullException(nameof(getViewUserProfile));
            _deleteUserAccountUseCase = deleteUserAccountUseCase ?? throw new ArgumentNullException(nameof(deleteUserAccountUseCase));
            _getUserQuestions = getUserQuestions ?? throw new ArgumentNullException(nameof(getUserQuestions));
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
        public IActionResult GetEmployee(GetEmployeeForUserRequest forUserRequest)
        {
            _getEmployeeForUserUseCase.Execute(forUserRequest, _modelPresenter);
            return PartialView("_CreateUser", _modelPresenter.Model);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            _securityManagerUseCase.VerifyUserIsAuthenticated(_modelPresenter);
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
            _securityManagerUseCase.VerifyUserIsAuthenticated(_modelPresenter);
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

        [HttpGet]
        public IActionResult MyQuestion()
        {
            var request = new GetUserQuestionsRequest
            {
                UserId = UserSecurityManager.UserId
            };
            _getUserQuestions.Execute(request, _modelPresenter);
            return View("MyQuestion", _modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult MyQuestion(GetUserQuestionsRequest request)
        {
            _getUserQuestions.Execute(request, _modelPresenter);
            return View("MyQuestion", _modelPresenter.Model);
        }
    }
}
