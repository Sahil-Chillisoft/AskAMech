using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Infrastructure.Data.Entities;
using AskAMech.Infrastructure.Data.Helpers;
using AskAMech.Core;
using AutoMapper;
using Dapper;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class AnswerRepository : IAnswersRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public AnswerRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Create(Answer answer)
        {
            #region SQL
            var sql = @"insert into Answers(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated)
                        values(@QuestionId, @Description, @AnsweredByUserId, @IsAcceptedAnswer, @DateCreated)";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql, new
            {
                QuestionId = answer.QuestionId,
                Description = answer.Description,
                AnsweredByUserId = answer.AnsweredByUserId,
                IsAcceptedAnswer = answer.IsAcceptedAnswer,
                DateCreated = answer.DateCreated
            });
            #endregion
        }

        public List<ViewAnswers> GetAnswers(int questionId)
        {
            #region SQL
            var sql = @"select a.Id, A.Description, a.AnsweredByUserId, 
                        up.Username, a.IsAcceptedAnswer, a.DateCreated, 
                        u.UserRoleId                        
                        from Answers a 
                        inner join UserProfile up on a.AnsweredByUserId = up.UserId
                        inner join Users u on up.UserId = u.Id
                        where a.QuestionId = @QuestionId 
                        order by a.IsAcceptedAnswer desc, a.DateCreated asc";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var answers = connection.Query<ViewAnswersEntity>(sql,
                new
                {
                    QuestionId = questionId
                }).ToList();
            #endregion

            return _mapper.Map<List<ViewAnswers>>(answers);
        }

        public List<ViewUserQuestionAnswers> GetUserQuestionAnswers(int userId, int? categoryId, Pagination pagination)
        {
            #region SQL
            var sql = @"select distinct q.id as QuestionId, q.Title as QuestionTitle,
                           c.Description as CategoryDescription, 
                           up.Username as AskedBy, q.DateCreated as QuestionCreationDate   
                           from Questions q
                           inner join Category c on q.CategoryId = c.Id
                           inner join Answers a on a.QuestionId = q.Id 
                           inner join UserProfile up on q.CreatedByUserId = up.UserId
                           where a.AnsweredByUserId = @UserId ";

            if (categoryId != 0)
                sql += "and q.CategoryId = @CategoryId ";

            sql += @"order by q.DateCreated
                     offset @Offset rows
                     fetch next @PageSize rows only ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var answers = connection.Query<ViewUserQuestionAnswersEntity>(sql,
                new
                {
                    UserId = userId,
                    CategoryId = categoryId,
                    Offset = pagination.Offset,
                    PageSize = pagination.PageSize
                }).ToList();
            #endregion

            return _mapper.Map<List<ViewUserQuestionAnswers>>(answers);
        }

        public int GetUserQuestionAnswerCount(int userId, int? categoryId)
        {
            #region SQL
            var sql = @"select distinct count(q.id) as QuestionAnswerCount 
                           from Questions q                           
                           inner join Answers a on a.QuestionId = q.Id 
                           inner join UserProfile up on q.CreatedByUserId = up.UserId
                           where a.AnsweredByUserId = @UserId ";

            if (categoryId != 0)
                sql += "and q.CategoryId = @CategoryId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var questionAnswerCount = connection.ExecuteScalar<int>(sql,
                new
                {
                    UserId = userId,
                    CategoryId = categoryId
                });
            #endregion

            return questionAnswerCount;
        }

        public void UpdateIsAcceptedAnswer(int questionId, int answerId, bool isAcceptedAnswer)
        {
            #region SQL
            var sql = @"update Answers 
                        set IsAcceptedAnswer = @IsAcceptedAnswer 
                        where QuestionId = @QuestionId 
                        and Id = @AnswerId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    IsAcceptedAnswer = isAcceptedAnswer,
                    QuestionId = questionId,
                    AnswerId = answerId
                });

            #endregion
        }

        public void ClearUpdatedAnswersForQuestion(int questionId)
        {
            #region SQL
            var sql = @"update Answers
                        set IsAcceptedAnswer = @IsAcceptedAnswer
                        where QuestionId = @QuestionId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    IsAcceptedAnswer = false,
                    QuestionId = questionId
                });
            #endregion
        }

        public Answer GetAnswer(int questionId, int answerId)
        {
            #region SQL
            var sql = @"select * from Answers 
                        where QuestionId = @QuestionId
                        and Id = @AnswerId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var answer = connection.Query<AnswersEntity>(sql,
                new
                {
                    QuestionId = questionId,
                    AnswerId = answerId
                }).FirstOrDefault();

            #endregion

            return _mapper.Map<Answer>(answer);
        }

        public void Update(Answer answer)
        {
            #region SQL
            var sql = @"update Answers
                        set Description = @Description
                        where QuestionId = @QuestionId 
                        and Id = @AnswerId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    Description = answer.Description,
                    QuestionId = answer.QuestionId,
                    AnswerId = answer.Id
                });
            #endregion
        }
    }
}