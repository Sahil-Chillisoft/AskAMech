﻿using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Core.Domain;

namespace AskAMech.Core.Gateways.Repositories
{
    public interface IUserDashboardRepository
    {
        UserDashboard GetKeyPerformanceIndicators(int userId);
    }
}
