﻿using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.UseCases.Requests;
using AskAMech.Core.UseCases.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Core.Gateways.Repositories;

namespace AskAMech.Core.UseCases
{
    public class CreateQuestionUseCase : ICreateQuestionUseCase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateQuestionUseCase(IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }


        public void Execute(CreateQuestionRequest request, IPresenter presenter)
        {
            var viewquestion = new ViewQuestions
            {
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                CreatedBy = UserSecurityManager.Username,
                CreatedByUserId = UserSecurityManager.UserId,
                AnswerCount = request.AnswerCount

            };
            _questionRepository.CreateQuestion(viewquestion);
            presenter.Success(new CreateQuestionResponse());

        }


    }
}