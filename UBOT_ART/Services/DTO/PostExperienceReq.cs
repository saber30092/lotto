using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Services.DTO
{
    public class PostExperienceReq
    {
        /// <summary>
        /// 參賽編號
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 代表機構
        /// </summary>
        public string Organization { get; set; }

        /// <summary>
        /// 參賽經驗
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 目前報名步驟
        /// </summary>
        public int Step { get; set; }
    }
}
