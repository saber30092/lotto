using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Controllers.ViewModel
{
    public class QueryUserViewModel
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
