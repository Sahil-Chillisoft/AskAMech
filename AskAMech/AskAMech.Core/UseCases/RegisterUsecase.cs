﻿using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;

namespace AskAMech.Core.UseCases
{
    public class RegisterUseCase: IRegisterUseCase
    {
        private readonly IUserRepository _userRepository;
        public RegisterUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void Execute(RegisterRequest request, IPresenter presenter)
        {

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                UserRoleId = (int) UserRole.PublicUser,
                DateLastLoggedIn = DateTime.Now,
                DateCreated = DateTime.Now,
                DateLastModified = DateTime.Now
            };
            var userId = CreateNewUserAndGetId(user);
        }


        private int CreateNewUserAndGetId(User user)
        {
            var userId = _userRepository.Create(user);
            return userId;
        }
    }
}
