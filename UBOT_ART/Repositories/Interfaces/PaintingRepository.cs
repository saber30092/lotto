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
using UBOT_ART.Services.DTO;

namespace UBOT_ART.Repositories.Interfaces
{
    public class PaintingRepository: IPaintingRepository
    {
        private readonly IOptionsSnapshot<SettingConfig> _settings;

        public PaintingRepository(IOptionsSnapshot<SettingConfig> settings)
        {
            _settings = settings;
        }

        public async Task<bool> PostPaiting(IEnumerable< PostPaintingReq> model)
        {
            bool result = false;
            string sql = @"INSERT INTO [dbo].[Paintings](Uid,PaintingNum,PaintingName,FileName,concept)
                          VALUES (@Uid,@PaintingNum,@PaintingName,@FileName,@concept)";
            using(IDbConnection connection=new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                connection.Open();
                using(var tran = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRow = await connection.ExecuteAsync(sql, model, transaction: tran);
                        if (affectedRow == 1)
                            result = true;
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message.ToString());
                    }
                    return result;
                }
            }
        }
    }
}
