using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Repositories.Entities
{
    public class CompetitionItem
    {
        /// <summary>
        /// 參賽名稱編號
        /// </summary>
        public int Cid { get; set; }

        /// <summary>
        /// 參賽名稱
        /// </summary>
        public string Item { get; set; }
    }
}
