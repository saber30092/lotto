using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Repositories.Entities;
using UBOT_ART.Services.DTO;

namespace UBOT_ART.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// 新增參賽者(第一頁)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> PostUser(PostUserReq model);

        /// <summary>
        /// 新增參賽者(第二頁)
        /// </summary>
        /// <param name="experienceReq"></param>
        /// <returns></returns>
        public Task<bool> PostExperience(PostExperienceReq experienceReq);

        /// <summary>
        /// 搜尋參賽者報名步驟
        /// </summary>
        /// <param name="userReq"></param>
        /// <returns></returns>
        public Task<User> QueryUserStepByIDNumberAndCellphone(QueryUserReq queryUserReq);

        /// <summary>
        /// 參賽者報名詳細資料
        /// </summary>
        /// <param name="userReq"></param>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetUserAllDetail(User userReq);

        /// <summary>
        /// 獲得User資本資料
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public Task<User> GetUserByUid(string uid);
    }
}
