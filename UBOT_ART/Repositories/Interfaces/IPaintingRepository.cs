using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Services.DTO;

namespace UBOT_ART.Repositories.Interfaces
{
    public interface IPaintingRepository
    {
        /// <summary>
        /// 第三頁存DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<bool> PostPaiting(IEnumerable<PostPaintingReq> model);

    }
}
