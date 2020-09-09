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

        public int Create(RegisterResponce registerResponce)
        {
            #region SQL
            var sql = "BEGIN; " +
                "INSERT INTO [dbo].[Users](Email, Password)" +
                "VALUES(@Email, @Password)" +
                "INSERT INTO [dbo].[UserProfile](Username)" +
                "VALUES(@Username)" +
                "COMMIT";
            #endregion

            #region Execution
            using var con = new SqlConnection(_sqlHelper.ConnectionString);
            var added = con.Execute(sql, registerResponce);
            #endregion
            return added;

        }
   }
}