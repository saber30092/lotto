using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Services.DTO
{
    public class QueryUserReq
    {
        /// <summary>
        /// 身分證字號
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        public string Cellphone { get; set; }
    }
}
