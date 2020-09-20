using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using System.Data.SqlClient;
using System.Linq;
using AskAMech.Infrastructure.Data.Entities;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;
using Dapper;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public UserRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public User GetUser(User user)
        {
            #region SQL

            var sql = "select * from Users ";
            sql += "where email = @Email and password = @Password ";

            #endregion

            #region Execution

            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var getUser = connection.Query<UserEntity>(sql,
                new
                {
                    Email = user.Email,
                    Password = user.Password
                }).FirstOrDefault();

            #endregion

            return getUser == null ? new User() : _mapper.Map<User>(getUser);
        }

        public int GetUserBy(int id)
        {
            throw new NotImplementedException();
        }

        public int GetUserBy(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsExistingUserEmail(string email)
        {
            #region SQL
            var sql = "select case when exists ";
            sql += "( ";
            sql += "select email from Users ";
            sql += "where email = @Email ";
            sql += ") then 1 else 0 ";
            sql += "end";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingEmail = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    Email = email
                });
            #endregion

            return isExistingEmail;
        }

        public int Create(User user)
        {
            #region SQL
            var sql = "insert into Users (Email, Password, UserRoleId, DateLastLoggedIn, DateCreated, DateLastModified)";
            sql += "output inserted.Id ";
            sql += "values(@Email, @Password, @UserRoleId, @DateLastLoggedIn, @DateCreated, @DateLastModified)";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userId = connection.ExecuteScalar<int>(sql,
                param: new
                {
                    Email = user.Email,
                    Password = user.Password,
                    UserRoleId = user.UserRoleId,
                    DateLastLoggedIn = user.DateLastLoggedIn,
                    DateCreated = user.DateCreated,
                    DateLastModified = user.DateLastModified
                });
            #endregion

            return userId;
        }

        public void UpdateLastLoggedInDate(int userId)
        {
            #region SQL

            var sql = "update Users ";
            sql += "set DateLastLoggedIn = @DateLastLoggedIn ";
            sql += "where Id = @UserId ";

            #endregion

            #region Execution

            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    DateLastLoggedIn = DateTime.Now,
                    UserId = userId
                });

            #endregion
        }
    }
}
