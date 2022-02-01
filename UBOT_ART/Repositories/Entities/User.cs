using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Repositories.Entities
{
    public class User
    {
        /// <summary>
        /// 報名人員id
        /// </summary>
        public int Uid { get; set; }

        /// <summary>
        /// 參賽編號
        /// </summary>
        public string CompetitionID { get; set; }

        /// <summary>
        /// 參賽者名字
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 護照英文名字
        /// </summary>
        public string UserEnName { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 身分證字號
        /// </summary>
        public string IDNumber { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birthday { get; set; }
        
        public string LineID { get; set; }

        /// <summary>
        /// 手機
        /// </summary>
        public string Cellphone { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// 戶籍地址(縣市)
        /// </summary>
        public string PermanentCity { get; set; }

        /// <summary>
        /// 戶籍地址(區/鄉/鎮/市)
        /// </summary>
        public string PermanentDistrict { get; set; }

        /// <summary>
        /// 戶籍地址
        /// </summary>
        public string PermanentAddress { get; set; }

        /// <summary>
        /// 通訊地址(縣市)
        /// </summary>
        public string MailingCity { get; set; }

        /// <summary>
        /// 通訊地址(區/鄉/鎮/市)
        /// </summary>
        public string MailingDistrict { get; set; }

        /// <summary>
        /// 通訊地址
        /// </summary>
        public string MailingAddress { get; set; }

        /// <summary>
        /// 參賽名稱編號
        /// </summary>
        public int Cid { get; set; }

        /// <summary>
        /// 目前報名步驟
        /// </summary>
        public int Step { get; set; }

        public CompetitionItem CompetitionItem { get; set; }

        public Experience Experience { get; set; }

        public Painting Painting { get; set; }
    }
}
