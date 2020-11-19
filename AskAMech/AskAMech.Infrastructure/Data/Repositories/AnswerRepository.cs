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

        public void Add(Answer answer)
        {
            #region SQL
            var sql = @"insert into Answer(QuestionId, Description, AnsweredByUserId, IsAcceptedAnswer, DateCreated)
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

        public List<ViewUserQuestionAnswers> GetUserQuestionAnswers(int userId, Pagination pagination)
        {
            #region SQL
            var sql = @"select distinct q.id as QuestionId, q.Description as QuestiotionDescription,
                           q.CategoryId as QuestionAnswerCategoryId, c.Description as CategoryDescription, 
                           up.Username as AskedBy, q.DateCreated as QuestionCreationDate   
                           from Questions q
                           inner join Category c on q.CategoryId = c.Id
                           inner join Answers a on a.QuestionId = q.Id 
                           inner join UserProfile up on q.CreatedByUserId = up.UserId
                           where a.AnsweredByUserId = @UserId";

            sql += @"order by QuestionCreationDate
                     offset @Offset rows
                     fetch next @PageSize rows only ";
            #endregion
            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var answers = connection.Query<ViewUserQuestionAnswersEntity>(sql,
                new
                {
                    UserId = userId,
                    Offset = pagination.Offset,
                    PageSize = pagination.PageSize
                }).ToList();
            #endregion
            return _mapper.Map<List<ViewUserQuestionAnswers>>(answers);
        }
        public int GetUserQuestionAnswerCount(int userId)
        {
            #region SQL
            var sql = @"select distinct count( q.id) as questionAnswerCount 
                           from Questions q
                           inner join Category c on q.CategoryId = c.Id
                           inner join Answers a on a.QuestionId = q.Id 
                           inner join UserProfile up on q.CreatedByUserId = up.UserId
                           where a.AnsweredByUserId = @UserId";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var questionAnswerCount = connection.ExecuteScalar<int>(sql,
                new
                {
                    UserId = userId
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
    }
}
