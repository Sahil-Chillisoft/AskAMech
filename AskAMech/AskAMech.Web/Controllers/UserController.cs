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
            var request = new EditUserProfileRequest
            {
                User = new User
                {
                    Id = UserSecurityManager.UserId
                }
            };

            _getUserProfileUseCase.Execute(request, _modelPresenter);
            return View(_modelPresenter.Model);
        }

        [HttpPost]
        public IActionResult Edit(EditUserProfileRequest request)
        {
            _editUserProfileUseCase.Execute(request, _modelPresenter);
            return Json(!_modelPresenter.HasValidationErrors ? 
                new { Success = true} : 
                new { Success = false});
        }

        [HttpPost]
        public IActionResult UpdatePassword()
        {
            /*
             * TODO:
             * Create a new response and request (UpdateUserPasswordRequest and UpdateUserPasswordResponse)
             * Both request and response must have the UserId, Password as properties
             * Create a new UseCase, call it UpdateUserPasswordUseCase
             * Create a new repository method in the UsersRepository called UpdatePassword and pass in the User object as a parameter eg? UpdatePassword(User user)
             * In your use case set the properties for the User object that is being passed back to the repository, this will be the Userid, Password, DateLastModified
             * Write SQL to update the password where the userid is equal to the userid parameter and also update the DateLastModified
             * Display a success Modal to the user that their password has been successfully update adn they will be required to to use their new password the next time they login to the system. 
             */
            throw new NotImplementedException();
        }

        public IActionResult EditSuccess()
        {
            return PartialView("_EditSuccess");
        }
    }
}
