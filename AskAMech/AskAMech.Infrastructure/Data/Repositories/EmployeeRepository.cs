using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using Dapper;
using AskAMech.Infrastructure.Data.Entities;
using System.Linq;
using System.Data.SqlClient;

namespace AskAMech.Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public EmployeeRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Create(Employee employee)
        {
            #region SQL
            var sql = @"insert into Employees(FirstName,LastName, IdNumber, Email, IsRegisterdUser, CreatedByUserId, DateCreated, LastModifiedByUserId, DateLastModified)
                        values (@FirstName, @LastName, @IdNumber, @Email, @IsRegisterdUser, @CreatedByUserId, @DateCreated, @LastModifiedByUserId,@DateLastModified)";
            #endregion
            #region Execution 
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var adduser = connection.Execute(sql, param: new
            {
                FirstName = employee.FirstName,
                LastName= employee.LastName,
                IdNumber=employee.IdNumber,
                Email=employee.Email,
                IsRegisterdUser=employee.IsRegisterdUser,
                CreatedByUserId=employee.CreatedByUserId,
                DateCreated=employee.DateCreated,
                LastModifiedByUserId=employee.LastModifiedByUserId,
                DateLastModified=employee.DateLastModified
            });
           
        }
    }
}
