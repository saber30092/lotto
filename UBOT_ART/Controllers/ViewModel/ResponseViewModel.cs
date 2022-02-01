﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Common.Enums;

namespace UBOT_ART.Controllers.ViewModel
{
    /// <summary>
    /// 回傳Ajax Model
    /// </summary>
    public class ResponseViewModel
    {
        /// <summary>
        /// 回傳狀態碼
        /// </summary>
        public ReturnCodeEnum RtnCode { get; set; } = ReturnCodeEnum.Ok;

        /// <summary>
        /// 回傳狀態訊息
        /// </summary>
        public string RtnMessage { get; set; } = "";

        /// <summary>
        /// 回傳狀態資料
        /// </summary>
        public object RtnData { get; set; } = default(object);
    }

    /// <typeparam name="T">回傳資料型態</typeparam>
    public class ResponseViewModel<T>
    {
        /// <summary>
        /// 回傳狀態碼
        /// </summary>
        public ReturnCodeEnum RtnCode { get; set; } = ReturnCodeEnum.Ok;

        /// <summary>
        /// 回傳狀態訊息
        /// </summary>
        public string RtnMessage { get; set; } = "";

        /// <summary>
        /// 回傳狀態資料
        /// </summary>
        public T RtnData { get; set; } = default(T);
    }
}
