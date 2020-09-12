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
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public UserProfileRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserProfile GetUserProfile(int userId)
        {
            #region SQL

            var sql = "select * from UserProfile ";
            sql += "where UserId = @UserId";
            
            #endregion

            #region Execution
            
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userProfile = connection.Query<UserProfileEntity>(sql,
                new
                {
                    UserId = userId
                }).FirstOrDefault();
            
            #endregion

            return userProfile == null ? new UserProfile() : _mapper.Map<UserProfile>(userProfile);
        }

        public void Create(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
