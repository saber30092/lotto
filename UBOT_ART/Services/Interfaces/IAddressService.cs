using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Controllers.ViewModel;

namespace UBOT_ART.Services.Interfaces
{
    public interface IAddressService
    {
        /// <summary>
        /// 獲得所有縣市
        /// </summary>
        /// <returns></returns>
        public Task<ResponseViewModel> GetListOfCity();

        /// <summary>
        /// 獲得縣市中的區域
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public Task<ResponseViewModel> GetDistrictsByCity(string cityID);

    }
}
