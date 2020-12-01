using System;
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
            var sql = @"select * 
                        from Users 
                        where email = @Email and password = @Password ";
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

        public User GetUserById(int id)
        {
            #region SQL
            var sql = @"select * 
                        from Users 
                        where Id = @Id ";
            #endregion

            #region Execustion
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var user = connection.Query<UserEntity>(sql,
                new
                {
                    Id = id
                }).FirstOrDefault();
            #endregion

            return user == null ? new User() : _mapper.Map<User>(user);
        }

        public User GetUserByEmployeeId(int employeeId)
        {
            #region SQL
            var sql = @"select * 
                        from Users 
                        where EmployeeId = @EmployeeId ";
            #endregion

            #region Execustion
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var user = connection.Query<UserEntity>(sql,
                new
                {
                    EmployeeId = employeeId
                }).FirstOrDefault();
            #endregion

            return user == null ? new User() : _mapper.Map<User>(user);
        }

        public bool IsExistingUserEmail(string email)
        {
            #region SQL
            var sql = @"select case when exists 
                        (
                            select email 
                            from Users 
                            where email = @Email 
                        ) then 1 else 0
                        end ";
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

        public bool IsExitingEmployeeUser(int employeeId)
        {
            #region SQL
            var sql = @"select case when exists 
                        (
                            select EmployeeId 
                            from Users 
                            where EmployeeId = @EmployeeId 
                        ) then 1 else 0
                        end ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingEmployeeUser = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    EmployeeId = employeeId
                });
            #endregion

            return isExistingEmployeeUser;
        }

        public int Create(User user)
        {
            #region SQL
            var sql = @"insert into Users (Email, Password, UserRoleId, EmployeeId, DateLastLoggedIn, DateCreated, DateLastModified)
                        output inserted.Id 
                        values(@Email, @Password, @UserRoleId, @EmployeeId, @DateLastLoggedIn, @DateCreated, @DateLastModified) ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userId = connection.ExecuteScalar<int>(sql,
                param: new
                {
                    Email = user.Email,
                    Password = user.Password,
                    UserRoleId = user.UserRoleId,
                    EmployeeId = user.EmployeeId,
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
            var sql = @"update Users 
                        set DateLastLoggedIn = @DateLastLoggedIn 
                        where Id = @UserId ";
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
        public void UpdatePassword(User user)
        {
            #region SQL
            var sql = @"update Users 
                        set Password = @Password, DateLastModified = @DateLastModified
                        where Id = @UserId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    UserId = user.Id,
                    Password = user.Password,
                    DateLastModified = user.DateLastModified
                });
            #endregion
        }

        public ViewUserProfile GetUserProfile(int id)
        {
            #region SQL
            var sql = @"select u.Id, up.Username, up.About, u.UserRoleId, u.DateCreated, u.DateLastLoggedIn, u.DateDeleted,
                        datediff(day, u.DateCreated, getdate()) as MembershipDuration,
                        case when q.QuestionCount is null then 0 else q.QuestionCount end as QuestionCount, 
                        case when a.AnswerCount is null then 0 else a.AnswerCount end as AnswerCount
                        from Users u
                        inner join UserProfile up on u.Id = up.UserId
                        left join 
                        (
	                        select CreatedByUserId as UserId, 
	                        count(Id) as QuestionCount  
	                        from Questions 
                            where DateDeleted is null
	                        group by CreatedByUserId
                        ) as q on u.Id = q.UserId
                        left join 
                        (
	                        select AnsweredByUserId as UserId, 
	                        count(Id) as AnswerCount
	                        from Answers
	                        group by AnsweredByUserId 
                        ) as a on u.Id = a.UserId
                        where u.Id = @UserId ";
            #endregion

            #region Execustion
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var userProfile = connection.Query<ViewUserProfileEntity>(sql,
                new
                {
                    UserId = id
                }).FirstOrDefault();
            #endregion

            return _mapper.Map<ViewUserProfile>(userProfile);
        }

        public void UpdateDateDeleted(int userId)
        {

            #region SQL
            var sql = @"update Users 
                        set DateDeleted = @DateDeleted 
                        where Id = @UserId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    DateDeleted = DateTime.Now,
                    UserId = userId
                });

            #endregion
        }

        public void UpdateDateDeletedForEmployeeUser(int employeeId, DateTime? dateDeleted)
        {
            #region SQL
            var sql = @"if exists (select * from Users where EmployeeId = @EmployeeId)
                        update Users
                        set DateDeleted = @DateDeleted
                        where EmployeeId = @EmployeeId";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    DateDeleted = dateDeleted,
                    EmployeeId = employeeId
                });
            #endregion
        }
    }
}
