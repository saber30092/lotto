using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Repositories.Entities;

namespace UBOT_ART.Repositories.Interfaces
{
    public interface IGameItemRepository
    {
        /// <summary>
        /// 獲得參賽項目
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CompetitionItem>> GetListOfCompetitionItems();

    }
}
