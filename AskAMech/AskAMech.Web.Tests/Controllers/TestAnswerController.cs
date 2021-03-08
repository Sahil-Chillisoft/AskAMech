using System;
using AskAMech.Core.Answers.Interfaces;
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

            [Ignore("wip")]
            [Test]
            public void GivenUnauthenticatedUser_ModelShouldHaveValidationErrors()
            {
                //Arrange 
                var builder = AnswersControllerBuilder.Create();
                var sut = builder
                    .WithUnauthenticatedUser()
                    .Build();
                //Act 
                sut.MyAnswers();
                //Assert                
                Assert.AreEqual(true, builder.ModelPresenter.HasValidationErrors);
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
                    ModelPresenter = Substitute.For<IModelPresenter>(),
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

            public AnswersControllerBuilder WithUnauthenticatedUser()
            {
                VerifyUserIsAuthenticatedUseCase.When(m => m.IsAuthenticated(ModelPresenter))
                    .Do(info => { ModelPresenter.Error(Arg.Any<ErrorResponse>(), true); });
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
