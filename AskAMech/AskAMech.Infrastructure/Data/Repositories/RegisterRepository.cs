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
using AskAMech.Core.UseCases.Responses;

namespace AskAMech.Infrastructure.Data.Repositories
{
   public class RegisterRepository: IRegisterRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public RegisterRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public int CreateUserM1(RegisterUser register)
        {
            #region SQL
            var sql =
                "INSERT INTO [dbo].[Users](Email, Password)" +
                "VALUES(@Email, @Password)";
            #endregion

            #region Execution
            using var con = new SqlConnection(_sqlHelper.ConnectionString);
            var added = con.Execute(sql, register);
            #endregion
            return added;

        }

        public int CreateUserM2(RegisterUser register)
        {
            #region SQL

            var sql = "INSERT INTO [dbo].[UserProfile](Username)" +
            "VALUES(@Username)";
            #endregion

            #region Execution
            using var conn = new SqlConnection(_sqlHelper.ConnectionString);
            var added = conn.Execute(sql, register);
            #endregion
            return added;
        }
    }
}