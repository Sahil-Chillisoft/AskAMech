﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AskAMech.Infrastructure.Data.Helpers
{
    public sealed class SqlHelper
    {
        public SqlHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}
