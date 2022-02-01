using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UBOT_ART.Common;
using UBOT_ART.Repositories.Entities;
using UBOT_ART.Repositories.Interfaces;

namespace UBOT_ART.Repositories
{
    public class GameItemRepository: IGameItemRepository
    {
        private readonly IOptionsSnapshot<SettingConfig> _settings;

        public GameItemRepository(IOptionsSnapshot<SettingConfig> settings)
        {
            _settings = settings;
        }

        public async Task<IEnumerable<CompetitionItem>> GetListOfCompetitionItems()
        {
            string sql = @"SELECT * FROM [dbo].[CompetitionItems]";

            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                var items = await _connection.QueryAsync<CompetitionItem>(sql);
                return items.ToList();
            }
        }
    }
}
