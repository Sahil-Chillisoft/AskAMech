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
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
        }

        public List<Employee> GetEmployees()
        {
            #region SQL
            var sql = @"select * from Employee ";
            #endregion

            #region Execution 
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var employeesList = connection.Query<EmployeeEntity>(sql).ToList();
            #endregion

            return _mapper.Map<List<Employee>>(employeesList);
        }

        public void Create(Employee employee)
        {
            #region SQL
            var sql = @"
                            insert into Employee(FirstName, LastName, IdNumber, Email, CreatedByUserId, DateCreated, LastModifiedByUserId, DateLastModified, IsActive)
                            values (@FirstName, @LastName, @IdNumber, @Email, @CreatedByUserId, @DateCreated, @LastModifiedByUserId, @DateLastModified, @IsActive)
                       ";
            #endregion

            #region Execution 
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                param: new
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    IdNumber = employee.IdNumber,
                    Email = employee.Email,
                    CreatedByUserId = employee.CreatedByUserId,
                    DateCreated = DateTime.Now,
                    LastModifiedByUserId = employee.LastModifiedByUserId,
                    DateLastModified = DateTime.Now,
                    IsActive = employee.IsActive
                });
            #endregion
        }

        public bool IsExistingEmployee(Employee employee)
        {
            #region SQL
            var sql = @"
                        select case when exists 
                        (
                            select Email 
                            from Employee 
                            where IdNumber = @IdNumber
                            or (FirstName = @FirstName 
                            and LastName = @LastName) 
                        ) then 1 else 0
                        end
                      ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingEmployee = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    IdNumber = employee.IdNumber,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                });
            #endregion

            return isExistingEmployee;
        }
    }
}
