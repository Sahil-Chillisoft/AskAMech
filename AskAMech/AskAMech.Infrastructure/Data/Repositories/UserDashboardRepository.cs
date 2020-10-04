using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Infrastructure.Data.Entities;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;
using Dapper;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class UserDashboardRepository : IUserDashboardRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public UserDashboardRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserDashboard GetKeyPerformanceIndicators(int userId)
        {
            #region SQL
            var sql = @"
                         select 
                         case when q.QuestionCount is null then 0 else q.QuestionCount end as QuestionCount, 
                         case when a.AnswerCount is null then 0 else a.AnswerCount end as AnswerCount
                         from Users u
                         left join 
                         (
	                        select CreatedByUserId as UserId, 
	                        count(Id) as QuestionCount  
	                        from Questions 
	                        group by CreatedByUserId
                         ) as q on u.Id = q.UserId
                         left join 
                         (
	                        select AnsweredByUserId as UserId, 
	                        count(Id) as AnswerCount
	                        from Answers
	                        group by AnsweredByUserId 
                         ) as a on u.Id = a.UserId
                         where u.Id = @UserId
                       ";
            #endregion
            
            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userDashboard = connection.Query<UserDashboardEntity>(sql,
                new
                {
                    UserId = userId
                }).FirstOrDefault();
            #endregion

            return _mapper.Map<UserDashboard>(userDashboard);
        }
    }
}
