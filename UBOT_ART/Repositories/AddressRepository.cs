using Dapper;
using Microsoft.Extensions.Configuration;
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
    public class AddressRepository: IAddressRepository
    {
        private readonly IConfiguration _config;
        private readonly IOptionsSnapshot<SettingConfig> _settings;

        public AddressRepository(IConfiguration config, IOptionsSnapshot<SettingConfig> settings)
        {
            _config = config;
            _settings = settings;
        }

        public async Task<IEnumerable<City>> GetAllCity()
        {
            string sql = @"SELECT * FROM [dbo].[City_M]";

            using (IDbConnection _connection=new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                var city = await _connection.QueryAsync<City>(sql);
                return city.ToList();
            }
        }

        public async Task<IEnumerable<District>> GetDistrictsByCity(string cityID)
        {
            string sql = @"SELECT * FROM [dbo].[District_M]
                          WHERE City_ID=@City_ID";
            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                var districts = await _connection.QueryAsync<District>(sql, new { City_ID = cityID });
                return districts.ToList();
            }

        }
    }
}
