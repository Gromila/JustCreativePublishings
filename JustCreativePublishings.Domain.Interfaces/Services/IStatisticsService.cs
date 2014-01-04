﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface IStatisticsService : IService
    {
        IDictionary<String, int> GetTopAuthors(int authorsNumber);

        IDictionary<String, int> GetUserStats(String userId);
    }
}
