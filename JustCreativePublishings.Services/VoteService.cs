using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;

namespace JustCreativePublishings.Services
{
    public class VoteService : BaseService, IVoteService
    {
        int IVoteService.UpdateVotesForPost(int postId, String userId, int voteValue)
        {
            var post = UnitOfWork.PostRepository.ReadById(postId);
            if (CheckVote(post, userId))
                AddVote(post, userId, voteValue);
            return CountVotes(post);
        }

        IEnumerable<Vote> IVoteService.GetLastVotes(String userId)
        {
            return
                UnitOfWork.VoteRepository.Read(filter: a => a.UserId == userId, includeProperties: "Post,User")
                    .Take(5)
                    .ToList();
        }

        private void AddVote(Post post, String userId, int value)
        {
            post.Votes.Add(new Vote { UserId = userId, PostId = post.Id, Value = value });
            UnitOfWork.Save();
        }

        private bool CheckVote(Post post, String userId)
        {
            return post.UserId != userId && post.Votes.All(vote => vote.UserId != userId);
        }
        
        private int CountVotes(Post post)
        {
            return post.Votes.Sum(vote => vote.Value);
        }
    }
}
