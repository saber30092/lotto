using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Controllers.ViewModel
{
    public class PostExperienceViewModel
    {
        /// <summary>
        /// 報名人員id
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
    }
}
