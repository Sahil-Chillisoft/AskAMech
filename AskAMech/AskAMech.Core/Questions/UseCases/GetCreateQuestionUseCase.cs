﻿using System;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.Questions.Interfaces;
using AskAMech.Core.Questions.Responses;

namespace AskAMech.Core.Questions.UseCases
{
    public class GetCreateQuestionUseCase : IGetCreateQuestionUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCreateQuestionUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public void Execute(IPresenter presenter)
        {
            var categories = _categoryRepository.GetCategories();
            var response = new CreateQuestionResponse
            {
                Question = new Question(),
                Categories = categories
            };

            presenter.Success(response);
        }
    }
}
