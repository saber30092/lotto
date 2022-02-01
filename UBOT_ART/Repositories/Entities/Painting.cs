using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Repositories.Entities
{
    public class Painting
    {
        /// <summary>
        /// 作品編號(流水號)
        /// </summary>
        public int Pid { get; set; }

        /// <summary>
        /// 報名人員id
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 作品編號(1~5)
        /// </summary>
        public int PaintingNum { get; set; }

        /// <summary>
        /// 作品名稱
        /// </summary>
        public string PaintingName { get; set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 創作理念
        /// </summary>
        public string concept { get; set; }
    }
}
