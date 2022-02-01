using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UBOT_ART.Common
{
    public class SettingConfig
    {
        public Connectionstring ConnectionSettings { get; set; }
    }

    public class Connectionstring
    {
        public string UCFA_Conn { get; set; }
    }
}
