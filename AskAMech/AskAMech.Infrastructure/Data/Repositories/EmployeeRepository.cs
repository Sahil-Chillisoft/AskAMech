using System;
using System.Collections.Generic;
using AskAMech.Infrastructure.Data.Helpers;
using AutoMapper;
using AskAMech.Core.Domain;
using AskAMech.Core.Gateways.Repositories;
using Dapper;
using AskAMech.Infrastructure.Data.Entities;
using System.Linq;
using System.Data.SqlClient;
using AskAMech.Core;

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

        public Employee GetEmployeeById(int? id)
        {
            #region 
            var sql = "select * from Employee where Id = @Id ";
            #endregion

            #region Execution
            var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var employee = connection.QueryFirstOrDefault<EmployeeEntity>(sql,
                new
                {
                    Id = id
                });
            #endregion

            return _mapper.Map<Employee>(employee);
        }

        public List<Employee> GetEmployees(string search, Pagination pagination)
        {
            #region SQL
            var sql = @"select * from Employee ";

            if (!string.IsNullOrEmpty(search))
                sql += @"where (FirstName + ' ' + LastName) like @Search  
                        or IdNumber like @Search ";

            sql += @"order by FirstName
                     offset @Offset rows
                     fetch next @PageSize rows only ";
            #endregion

            #region Execution 
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var employeesList = connection.Query<EmployeeEntity>(sql,
                new
                {
                    Search = $"%{search}%",
                    Offset = pagination.Offset,
                    PageSize = pagination.PageSize
                }).ToList();
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

        public bool IsExistingEmployeeEmail(string email)
        {
            #region SQL
            var sql = @"select case when exists 
                        (
                            select Email 
                            from Employee 
                            where Email = @Email 
                            and Email <> @Email
                        ) then 1 else 0
                        end ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingEmployeeEmail = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    Email = email
                });
            #endregion

            return isExistingEmployeeEmail;
        }

        public bool IsExistingEmployeeIdNumber(string idNumber)
        {
            #region SQL
            var sql = @"select case when exists 
                        (
                            select IdNumber 
                            from Employee 
                            where IdNumber = @IdNumber 
                            and IdNumber <> @IdNumber
                        ) then 1 else 0
                        end ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingEmployeeIdNumber = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    IdNumber = idNumber
                });
            #endregion

            return isExistingEmployeeIdNumber;
        }

        public List<ViewEmployee> GetEmployeesForAutocomplete(string search)
        {
            #region SQL
            var sql = @"select top 7 Id, (FirstName + ' ' + LastName) as FullName 
                        from Employee 
                        where (FirstName + ' ' + LastName) like @Search  
                        or IdNumber like @Search ";
            #endregion

            #region Execution
            var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var employees = connection.Query<ViewEmployeeEntity>(sql,
                new
                {
                    Search = $"%{search}%"
                }).ToList();
            #endregion

            return _mapper.Map<List<ViewEmployee>>(employees);
        }

        public int GetCount(string? search)
        {
            #region SQL
            var sql = @"select count(Id) as EmployeeCount 
                        from Employee
                        where (FirstName + ' ' + LastName) like @Search  
                        or IdNumber like @Search ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var employeeCount = connection.ExecuteScalar<int>(sql,
                new
                {
                    Search = $"%{search}%"
                });
            #endregion

            return employeeCount;
        }

        public void Update(Employee employee)
        {
            #region SQL
            var sql = @"update Employee
                        set FirstName=@FirstName, LastName = @LastName, IdNumber = @IdNumber,
                        Email = @Email, LastModifiedByUserId = @LastModifiedByUserId, DateLastModified=@DateLastModified, 
                        IsActive = @IsActive
                        where Id = @EmployeeId ";
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
                    LastModifiedByUserId = employee.LastModifiedByUserId,
                    DateLastModified = employee.DateLastModified,
                    IsActive = employee.IsActive,
                    EmployeeId = employee.Id
                });
            #endregion
        }

        public void UpdateActiveStatus(Employee employee)
        {
            #region SQL
            var sql = @"update Employee
                        set IsActive = @IsActive, 
                        LastModifiedByUserId = @LastModifiedByUserId, 
                        DateLastModified = @DateLastModified
                        where Id = @EmployeeId ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            connection.Execute(sql,
                new
                {
                    IsActive = employee.IsActive,
                    LastModifiedByUserId = employee.LastModifiedByUserId,
                    DateLastModified = employee.DateLastModified,
                    EmployeeId = employee.Id
                });
            #endregion
        }
    }
}
