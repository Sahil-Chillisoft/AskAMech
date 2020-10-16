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

        public void Create()
        {
            throw new NotImplementedException();
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
