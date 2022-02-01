using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Repositories.Entities
{
    public class Experience
    {
        /// <summary>
        /// 經驗編號
        /// </summary>
        public int Eid { get; set; }

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
    }
}
