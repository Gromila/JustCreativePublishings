using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Interfaces.Services;
using JustCreativePublishings.Services;
using Newtonsoft.Json;

namespace JustCreativePublishings.Web.Controllers
{
    public class PostApiController : ApiController
    {
        private IPostService postService = new PostService();

        // GET api/<controller>
        public IEnumerable<Post> Get()
        {
            return
                postService.GetPosts()
                    .Select(
                        post =>
                            new Post()
                            {
                                Title = post.Title,
                                CreationDate = post.CreationDate,
                                Chapters = post.Chapters.Select(chapter => new Chapter() {Content = chapter.Content, Id = chapter.Id, OrderNumber = chapter.OrderNumber, PostId = chapter.PostId, Title = chapter.Title }).ToList(),
                                Id = post.Id,
                                IsPublished = true,
                                LastUpdateDate = post.LastUpdateDate,
                                ShortDescription = post.ShortDescription,
                                Tags = post.Tags.Select(tag => new Tag() { Content = tag.Content, Id = tag.Id }).ToList(),
                                UserId = post.UserId,
                                Votes = post.Votes.Select(vote => new Vote() { Id = vote.Id, Value = vote.Value, PostId = vote.PostId, UserId = vote.UserId }).ToList()
                            });

        }

        // GET api/<controller>/5
        public Post Get(int id)
        {
            var post = postService.GetPostById(id);
            return post == null ? null : new Post()
            {
                Title = post.Title,
                CreationDate = post.CreationDate,
                Chapters = post.Chapters.Select(chapter => new Chapter() { Content = chapter.Content, Id = chapter.Id, OrderNumber = chapter.OrderNumber, PostId = chapter.PostId, Title = chapter.Title }).ToList(),
                Id = post.Id,
                IsPublished = true,
                LastUpdateDate = post.LastUpdateDate,
                ShortDescription = post.ShortDescription,
                Tags = post.Tags.Select(tag => new Tag() { Content = tag.Content, Id = tag.Id }).ToList(),
                UserId = post.UserId,
                Votes = post.Votes.Select(vote => new Vote() { Id = vote.Id, Value = vote.Value, PostId = vote.PostId, UserId = vote.UserId }).ToList()
            };
        }

        // POST api/<controller>
        public void Post([FromBody]Post value)
        {
            postService.Create(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Post value)
        {
            value.Id = id;
            postService.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            postService.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            postService.Dispose();
            base.Dispose(disposing);
        }
    }
}