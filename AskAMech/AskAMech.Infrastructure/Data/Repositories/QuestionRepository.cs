﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AskAMech.Core;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Infrastructure.Data.Entities;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;
using Dapper;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public QuestionRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<ViewQuestions> GetQuestions(string? search, int? categoryId, Pagination pagination)
        {
            #region SQL
            var sql = @"select q.Id, q.Title, q.Description, q.CategoryId, c.Description as Category, 
                        q.CreatedByUserId, up.Username as CreatedBy, q.DateCreated,
                        case when a.AnswerCount is null then 0 else a.AnswerCount end as AnswerCount  
                        from Questions q
                        inner join Category c on q.CategoryId = c.Id
                        inner join UserProfile up on q.CreatedByUserId = up.UserId
                        left join
                        (
	                        select QuestionId, count(Id) as AnswerCount
	                        from Answers 
	                        group by QuestionId
                        ) as a on q.Id = a.QuestionId
                        where q.DateDeleted is null ";

            if (!string.IsNullOrEmpty(search))
                sql += "and q.Description like @Search ";

            if (categoryId != 0)
                sql += "and q.CategoryId = @CategoryId ";

            sql += @"order by q.DateCreated desc
                     offset @Offset rows
                     fetch next @PageSize rows only ";
            #endregion

            #region Execution 
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var questions = connection.Query<ViewQuestionsEntity>(sql,
                new
                {
                    Search = $"%{search}%",
                    CategoryId = categoryId,
                    Offset = pagination.Offset,
                    PageSize = pagination.PageSize
                }).ToList();
            #endregion

            return _mapper.Map<List<ViewQuestions>>(questions);
        }

        public Question GetQuestion(int id)
        {
            #region SQL
            var sql = @"select * 
                        from Questions 
                        where Id = @Id ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var question = connection.Query<QuestionEntity>(sql,
                new
                {
                    Id = id
                }).FirstOrDefault();
            #endregion

            return _mapper.Map<Question>(question);
        }

        public int GetCount(string? search, int? categoryId)
        {
            #region SQL
            var sql = @"select count(q.Id) as CountQuestions
                        from Questions q
                        inner join Category c on q.CategoryId = c.Id                        
                        where 1 = 1 ";

            if (!string.IsNullOrEmpty(search))
                sql += "and q.Description like @Search ";

            if (categoryId != 0)
                sql += "and q.CategoryId = @CategoryId ";
            #endregion

            #region Execustion
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var questionCount = connection.ExecuteScalar<int>(sql,
                new
                {
                    Search = $"%{search}%",
                    CategoryId = categoryId
                });
            #endregion

            return questionCount;
        }

        public int GetUserQuestionCount(int userId, int? categoryId)
        {
            #region SQL
            var sql = @"select count(Id) as QuestionCount
                        from Questions
                        where CreatedByUserId = @UserId ";

            if (categoryId != 0)
                sql += "and CategoryId = @CategoryId";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userQuestionCount = connection.ExecuteScalar<int>(sql,
                new
                {
                    userId = userId,
                    CategoryId = categoryId
                });
            #endregion

            return userQuestionCount;
        }

        public void CreateQuestion(Question question)
        {
            #region SQL
            var sql = @"insert into Questions (Title, Description, CategoryId, CreatedByUserId, DateCreated, DateLastModified)                        
                        values(@Title, @Description, @CategoryId, @CreatedByUserId, @DateCreated, @DateLastModified) ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                param: new
                {
                    Title = question.Title,
                    Description = question.Description,
                    CategoryId = question.CategoryId,
                    CreatedByUserId = question.CreatedByUserId,
                    DateCreated = question.DateCreated,
                    DateLastModified = question.DateLastModified
                });
            #endregion
        }

        public ViewQuestionDetails GetQuestionDetails(int id)
        {
            #region SQL

            var sql = @"select q.Id, q.Title, q.Description, c.Description as CategoryDescription, 
                        q.CreatedByUserId, up.Username, q.DateCreated, q.DateLastModified, q.DateDeleted 
                        from Questions q                        
                        inner join UserProfile up on q.CreatedByUserId = up.UserId
                        inner join Category c on q.CategoryId = c.Id
                        where q.Id = @Id ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var questionDetails = connection.Query<ViewQuestionDetailsEntity>(sql,
                new
                {
                    Id = id
                }).FirstOrDefault();
            #endregion

            return _mapper.Map<ViewQuestionDetails>(questionDetails);
        }

        public void Update(Question question)
        {
            #region SQL
            var sql = @"update Questions 
                        set Title = @Title, Description = @Description, 
                        CategoryId = @CategoryId, DateLastModified = @DateLastModified
                        where Id = @Id ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    Title = question.Title,
                    Description = question.Description,
                    CategoryId = question.CategoryId,
                    DateLastModified = question.DateLastModified,
                    Id = question.Id
                });
            #endregion
        }

        public void Delete(int id)
        {
            #region SQL
            var sql = @"update Questions 
                        set DateDeleted = @DateDeleted
                        where Id = @Id ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    Id = id,
                    DateDeleted = DateTime.Now
                });
            #endregion
        }

        public List<ViewUserQuestions> GetUserQuestions(int userId, int? categoryId, Pagination pagination)
        {
            #region SQL
            var sql = @"select q.*, C.Description as CategoryDescription, 
                        case when a.AnswerCount is null then 0 else a.AnswerCount end as AnswerCount
                        from Questions q
                        inner join Category c on q.CategoryId = c.Id
                        left join 
                        (
	                        select QuestionId, 
	                        count(Id) as AnswerCount
	                        from Answers
	                        group by QuestionId
                        ) as a on q.Id = a.QuestionId
                        where q.CreatedByUserId = @UserId
                        and q.DateDeleted is null ";

            if (categoryId != 0)
                sql += "and CategoryId = @categoryId ";

            sql += @"order by q.DateCreated 
                     offset @Offset rows
                     fetch next @PageSize rows only";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userQuestions = connection.Query<ViewUserQuestionsEntity>(sql,
                new
                {
                    UserId = userId,
                    CategoryId = categoryId,
                    Offset = pagination.Offset,
                    PageSize = pagination.PageSize
                }).ToList();
            #endregion

            return _mapper.Map<List<ViewUserQuestions>>(userQuestions);
        }
    }
}
