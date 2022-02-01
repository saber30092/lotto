﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Controllers.ViewModel
{
    public class PostPaintingViewModel
    {
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

        public IFormFile ProfileFile { get; set; }

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
