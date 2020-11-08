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
            var sql = @"select * 
                        from UserProfile 
                        where UserId = @UserId ";
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

        public bool IsExistingUsername(string username)
        {
            #region SQL
            var sql = @"select case when exists 
                        ( 
                            select username 
                            from UserProfile 
                            where username = @Username 
                        ) then 1 else 0 
                        end ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingName = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    Username = username
                });
            #endregion

            return isExistingName;
        }

        public void Create(UserProfile userProfile)
        {
            #region SQL
            var sql = @"insert into UserProfile (UserId, Username, About, DateLastModified)                        
                        values(@UserId, @Username, @About, @DateLastModified) ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                param: new
                {
                    UserId = userProfile.UserId,
                    Username = userProfile.Username,
                    About = userProfile.About,
                    DateLastModified = userProfile.DateLastModified
                });
            #endregion
        }
        public void UpdateUserProfile(UserProfile userProfile)
        {
            #region SQL
            var sql = @"
                        update UserProfile 
                        set UserId=@UserId, Username=@Username, DateLastModified=@DateLastModified                        
                        where Id=@UserId
                      ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                param: new
                {
                    UserId = userProfile.UserId,
                    Username = userProfile.Username,
                    DateLastModified = DateTime.Now
                });
            #endregion
        }
    }
}
