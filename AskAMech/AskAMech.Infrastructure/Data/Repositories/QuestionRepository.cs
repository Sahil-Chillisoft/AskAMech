#nullable enable
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
                        where 1 = 1 ";

            if (!string.IsNullOrEmpty(search))
                sql += "and q.Description like @Search ";

            if (categoryId != 0)
                sql += "and q.CategoryId = @CategoryId ";

            sql += @"order by q.DateCreated
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
    }
}
