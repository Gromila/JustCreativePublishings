using System;
using System.Collections.Generic;
using System.Linq;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public class StatisticsService : BaseService, IStatisticsService
    {
        IDictionary<String, int> IStatisticsService.GetTopAuthors(int authorsNumber)
        {
            var users = UnitOfWork.UserRepository.Read(orderBy: u => u.OrderByDescending(p => p.Posts.Count)).Distinct().Take(authorsNumber);
            var postsNumber = UnitOfWork.PostRepository.Read(filter: p => p.IsPublished).Count();
            return postsNumber == 0 ? null : users.ToDictionary(user => user.UserName, user => (UnitOfWork.UserRepository.ReadById(user.Id).Posts.Count*100)/postsNumber);
        }

        IDictionary<String, int> IStatisticsService.GetUserStats(String userId)
        {
            var users = UnitOfWork.UserRepository.Read(filter: u => u.Id == userId);
            var postsNumber = UnitOfWork.PostRepository.Read(filter: p => p.IsPublished).Count();
            return postsNumber == 0
                ? null
                : users.ToDictionary(user => user.UserName,
                    user => (UnitOfWork.UserRepository.ReadById(user.Id).Posts.Count*100)/postsNumber);
        }
    }
}
