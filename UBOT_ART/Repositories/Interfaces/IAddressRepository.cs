using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Repositories.Entities;

namespace UBOT_ART.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        /// <summary>
        /// 獲得所有縣市
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<City>> GetAllCity();

        /// <summary>
        /// 獲得縣市中的所有區域
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public Task<IEnumerable<District>> GetDistrictsByCity(string cityID);

    }
}
