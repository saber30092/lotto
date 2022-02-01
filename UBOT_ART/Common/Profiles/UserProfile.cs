using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Controllers.ViewModel;
using UBOT_ART.Services.DTO;

namespace UBOT_ART.Common.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<PostUserViewModel, PostUserReq>();
            CreateMap<QueryUserViewModel, QueryUserReq>();
            CreateMap<PostExperienceViewModel, PostExperienceReq>();
            CreateMap<PostUserViewModel, QueryUserReq>();
            CreateMap<PostPaintingViewModel, PostPaintingReq>();
        }
    }
}
