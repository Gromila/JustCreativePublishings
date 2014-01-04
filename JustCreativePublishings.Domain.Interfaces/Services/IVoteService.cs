using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface IVoteService : IService
    {
        int UpdateVotesForPost(int postId, String userId, int voteValue);

        IEnumerable<Vote> GetLastVotes(String userId); 
    }
}
