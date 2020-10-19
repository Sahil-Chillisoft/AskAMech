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
    public class RolesRepository : IRolesRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public RolesRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public List<Roles> getAllRoles()
        {
            #region SQL
            var sql = @"select * from Roles ";
            #endregion
            #region Execution 
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var rolesList = connection.Query<RolesEntity>(sql).ToList();
            #endregion
            return _mapper.Map<List<Roles>>(rolesList);
        }
        public int Create(Roles roles)
        {
            #region SQL
            var sql = @"
                        insert into Roles (Description)
                        output inserted.Id 
                        values(@Description)
                      ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var roleId = connection.ExecuteScalar<int>(sql,
                param: new
                {
                    Description = roles.Description
                
                });
            #endregion

            return roleId;
        }

        public bool IsExistingRole(string description)
        {
            #region SQL
            var sql = @"
                        select case when exists 
                        (
                            select description 
                            from Roles 
                            where description = @Description 
                        ) then 1 else 0
                        end
                      ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingRole = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    Description = description
                });
            #endregion

            return isExistingRole;
        }
    }
}
