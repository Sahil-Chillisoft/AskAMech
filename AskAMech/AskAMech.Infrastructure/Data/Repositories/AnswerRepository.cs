using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Infrastructure.Data.Entities;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;
using Dapper;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class AnswerRepository: IAnswersRepository
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
                        up.Username, a.IsAcceptedAnswer, a.DateCreated 
                        from Answers a 
                        inner join UserProfile up on a.AnsweredByUserId = up.UserId
                        where a.QuestionId = @QuestionId ";
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
    }
}
