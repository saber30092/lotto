using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Controllers.ViewModel;

namespace UBOT_ART.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 第一頁存入DB
        /// </summary>
        /// <param name="postUserViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostUser(PostUserViewModel postUserViewModel);

        /// <summary>
        /// 查詢參賽者報名步驟
        /// </summary>
        /// <param name="queryUserViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> QueryUser(QueryUserViewModel queryUserViewModel);

        /// <summary>
        /// 第二頁存入DB
        /// </summary>
        /// <param name="postExperienceViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostExperience(PostExperienceViewModel postExperienceViewModel);

        /// <summary>
        /// 第三頁存入DB
        /// </summary>
        /// <param name="postPaintingViewModel"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> PostPainting(string uid,IEnumerable<PostPaintingViewModel> postPaintingViewModel );
    }
}
