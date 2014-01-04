using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using JustCreativePublishings.Domain.Entities;
using JustCreativePublishings.Web.Models;

namespace JustCreativePublishings.Web.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<PostViewModel, Post>();
            Mapper.CreateMap<ChapterViewModel, Chapter>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Chapter, ChapterViewModel>();
            Mapper.CreateMap<Vote, VoteViewModel>();
            Mapper.CreateMap<VoteViewModel, Vote>();
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}