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
    public class LoginRepository : ILoginRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public LoginRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public User GetUser(string email, string password)
        {
            #region SQL
            var sql = "select * from Users ";
            sql += "where email = @Email and password = @Password";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var user = connection.Query<UserEntity>
            (
                sql,
                new
                {
                    Email = email,
                    Password = password
                }
            ).FirstOrDefault();
            #endregion

            return _mapper.Map<User>(user);
        }
    }
}
