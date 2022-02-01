using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Common.Enums
{
    public enum StepEnum
    {
        [Description("基本資料完成")]
        FirstPage = 1 ,

        [Description("參賽經驗完成")]
        SecondPage = 2 ,

        [Description("作品上傳完成")]
        ThirdPage = 3 ,
    }
}
