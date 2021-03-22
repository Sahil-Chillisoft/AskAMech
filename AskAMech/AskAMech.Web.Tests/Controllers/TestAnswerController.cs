using System;
using System.Collections.Generic;
using System.Net;
using AskAMech.Core;
using AskAMech.Core.Answers.Interfaces;
using AskAMech.Core.Answers.Requests;
using AskAMech.Core.Answers.Responses;
using AskAMech.Core.Domain;
using AskAMech.Core.Error;
using AskAMech.Core.Security.Interfaces;
using AskAMech.Web.Controllers;
using AskAMech.Web.Presenters;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace AskAMech.Web.Tests.Controllers
{
    [TestFixture]
    public class TestAnswerController
    {
        [TestFixture]
        public class MyAnswers
        {
            [TestFixture]
            public class Get
            {
                [Test]
                public void ShouldBeAnHttpGetRequest()
                {
                    //Arrange 
                    var myAnswersControllerType = typeof(AnswerController);

                    //Act 
                    var propertyInfo = myAnswersControllerType.GetMethod("MyAnswers", new Type[] { });

                    //Assert                
                    propertyInfo.Should().BeDecoratedWith<HttpGetAttribute>();
                }

                [Test]
                public void ShouldCallVerifyUserIsAuthenticatedUseCase()
                {
                    //Arrange 
                    var builder = AnswersControllerBuilder.Create();
                    var sut = builder
                        .Build();

                    //Act 
                    sut.MyAnswers();

                    //Assert                
                    builder.VerifyUserIsAuthenticatedUseCase.Received(1).IsAuthenticated(Arg.Any<IModelPresenter>());
                }

                [Test]
                public void GivenAuthenticatedUser_ModelShouldHaveNoValidationErrors()
                {
                    //Arrange 
                    var builder = AnswersControllerBuilder.Create();
                    var sut = builder
                        .WithAuthenticatedUser()
                        .Build();

                    //Act 
                    sut.MyAnswers();

                    //Assert                
                    builder.ModelPresenter.HasValidationErrors.Should().BeFalse();
                }

                [Test]
                public void GivenUnauthenticatedUser_ModelShouldHaveValidationErrors()
                {
                    //Arrange 
                    var errorResponse = new ErrorResponse
                    {
                        Message = "Access Denied",
                        Code = HttpStatusCode.Unauthorized
                    };
                    var builder = AnswersControllerBuilder.Create();
                    var sut = builder
                        .WithUnauthenticatedUser(errorResponse)
                        .Build();

                    //Act 
                    sut.MyAnswers();

                    //Assert     
                    var model = builder.ModelPresenter.Model as ErrorResponse;
                    Assert.AreEqual(true, builder.ModelPresenter.HasValidationErrors);
                    Assert.AreEqual(errorResponse.Message, model?.Message);
                    Assert.AreEqual(errorResponse.Code, model?.Code);
                }

                [Test]
                public void ShouldCallGetUserQuestionAnswersUseCase()
                {
                    //Arrange 
                    var builder = AnswersControllerBuilder.Create();
                    var sut = builder.Build();

                    //Act             
                    sut.MyAnswers();

                    //Assert
                    builder.GetUserQuestionAnswersUseCase.Received(1).Execute(Arg.Any<GetUserQuestionAnswersRequest>(), Arg.Any<IPresenter>());
                }

                [Test]
                public void GivenIsAuthorizedUser_ShouldRenderViewWithModel()
                {
                    //Arrange 
                    var response = new GetUserQuestionAnswersResponse
                    {
                        CategoryId = 1,
                        Categories = new List<Category>
                        {
                            new Category
                            {
                                Id = 1,
                                Description = "Category 1"
                            },
                            new Category
                            {
                                Id = 2,
                                Description = "Category 2"
                            }
                        },
                        UserQuestionAnswers = new List<ViewUserQuestionAnswers>
                        {
                            new ViewUserQuestionAnswers
                            {
                                QuestionId = 1,
                                CategoryDescription = "Description 1"
                            },
                            new ViewUserQuestionAnswers
                            {
                                QuestionId = 2,
                                CategoryDescription = "Description 2"
                            }
                        },
                        Pagination = new Pagination
                        {
                            IsPagingRequest = false
                        }
                    };
                    var builder = AnswersControllerBuilder.Create();
                    var sut = builder
                        .WithGetUserQuestionAnswerUseCase(response)
                        .Build();

                    //Act             
                    var viewResult = sut.MyAnswers() as ViewResult;
                    var model = viewResult?.Model as GetUserQuestionAnswersResponse;

                    //Assert
                    viewResult.Should().NotBeNull();
                    model.Should().BeSameAs(response);
                }
            }
        }

        internal class AnswersControllerBuilder
        {
            public IModelPresenter ModelPresenter { get; private set; }
            public IGetUserQuestionAnswersUseCase GetUserQuestionAnswersUseCase { get; private set; }
            public IGetConfirmAcceptedAnswerUseCase GetConfirmAcceptedAnswerUseCase { get; private set; }
            public IUpdateIsAcceptedAnswerUseCase UpdateIsAcceptedAnswerUseCase { get; private set; }
            public ICreateAnswerUseCase CreateAnswerUseCase { get; private set; }
            public IGetUserAnswerUseCase GetUserAnswerUseCase { get; private set; }
            public IEditAnswerUseCase EditAnswerUseCase { get; private set; }
            public IDeleteAnswerUseCase DeleteAnswerUseCase { get; private set; }
            public IVerifyUserIsAuthenticatedUseCase VerifyUserIsAuthenticatedUseCase { get; private set; }

            private AnswersControllerBuilder()
            {
            }

            public static AnswersControllerBuilder Create()
            {
                var builder = new AnswersControllerBuilder
                {
                    ModelPresenter = new ModelPresenter(),
                    GetUserQuestionAnswersUseCase = Substitute.For<IGetUserQuestionAnswersUseCase>(),
                    GetConfirmAcceptedAnswerUseCase = Substitute.For<IGetConfirmAcceptedAnswerUseCase>(),
                    UpdateIsAcceptedAnswerUseCase = Substitute.For<IUpdateIsAcceptedAnswerUseCase>(),
                    CreateAnswerUseCase = Substitute.For<ICreateAnswerUseCase>(),
                    GetUserAnswerUseCase = Substitute.For<IGetUserAnswerUseCase>(),
                    EditAnswerUseCase = Substitute.For<IEditAnswerUseCase>(),
                    DeleteAnswerUseCase = Substitute.For<IDeleteAnswerUseCase>(),
                    VerifyUserIsAuthenticatedUseCase = Substitute.For<IVerifyUserIsAuthenticatedUseCase>()
                };
                return builder;
            }

            public AnswersControllerBuilder WithAuthenticatedUser()
            {
                VerifyUserIsAuthenticatedUseCase.When(m => m.IsAuthenticated(ModelPresenter))
                    .Do(info => { ModelPresenter.Success(true); });
                return this;
            }

            public AnswersControllerBuilder WithUnauthenticatedUser(ErrorResponse errorResponse)
            {
                VerifyUserIsAuthenticatedUseCase.When(m => m.IsAuthenticated(ModelPresenter))
                    .Do(info => { ModelPresenter.Error(errorResponse, true); });
                return this;
            }

            public AnswersControllerBuilder WithGetUserQuestionAnswerUseCase(GetUserQuestionAnswersResponse response)
            {
                GetUserQuestionAnswersUseCase.When(m => m.Execute(Arg.Any<GetUserQuestionAnswersRequest>(), ModelPresenter))
                    .Do(info => { ModelPresenter.Success(response); });
                return this;
            }

            public AnswerController Build()
            {
                return new AnswerController
                (
                    ModelPresenter,
                    GetUserQuestionAnswersUseCase,
                    GetConfirmAcceptedAnswerUseCase,
                    UpdateIsAcceptedAnswerUseCase,
                    CreateAnswerUseCase,
                    GetUserAnswerUseCase,
                    EditAnswerUseCase,
                    DeleteAnswerUseCase,
                    VerifyUserIsAuthenticatedUseCase
                );
            }
        }

    }
}
