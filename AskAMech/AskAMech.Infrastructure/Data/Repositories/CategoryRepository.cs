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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlHelper _sqlHelper;
        private readonly IMapper _mapper;

        public CategoryRepository(SqlHelper sqlHelper, IMapper mapper)
        {
            _sqlHelper = sqlHelper ?? throw new ArgumentNullException(nameof(sqlHelper));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public int Create(Category category)
        {
            #region SQL
            var sql = @"
                        insert into Category (Description)
                        output inserted.Id 
                        values(@Description)
                      ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var categoryId = connection.ExecuteScalar<int>(sql,
                param: new
                {
                    Description = category.Description

                });
            #endregion

            return categoryId;
        }

        public bool IsExistingCategory(string description)
        {
            #region SQL
            var sql = @"
                        select case when exists 
                        (
                            select description 
                            from Category 
                            where description = @Description 
                        ) then 1 else 0
                        end
                      ";
            #endregion

            #region Execution
            using var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var isExistingCategory = connection.ExecuteScalar<bool>(sql,
                param: new
                {
                    Description = description
                });
            #endregion

            return isExistingCategory;
        }

        public List<Category> GetCategories()
        {
            #region  SQL
            var sql = @"select * from Category";
            #endregion

            #region Execution

            var connection = new SqlConnection(_sqlHelper.ConnectionString);
            var categories = connection.Query<CategoryEntity>(sql).ToList();
            #endregion

            return _mapper.Map<List<Category>>(categories);
        }
    }
}
