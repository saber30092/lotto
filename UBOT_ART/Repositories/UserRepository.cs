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
using UBOT_ART.Services.DTO;

namespace UBOT_ART.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly IOptionsSnapshot<SettingConfig> _settings;

        public UserRepository(IConfiguration config, IOptionsSnapshot<SettingConfig> settings)
        {
            _config = config;
            _settings = settings;
        }
        
        public async Task<bool> PostUser(PostUserReq model)
        {
            bool result = false; 
            string sql = @"INSERT INTO [dbo].[Users](UserName,UserEnName,Gender,IDNumber,Birthday,LineID,Cellphone,Email,PermanentCity,PermanentDistrict,PermanentAddress,MailingCity,MailingDistrict,MailingAddress,Cid,Step)
                           VALUES(@UserName,@UserEnName,@Gender,@IDNumber,@Birthday,@LineID,@Cellphone,@Email,@PermanentCity,@PermanentDistrict,@PermanentAddress,@MailingCity,@MailingDistrict,@MailingAddress,@Cid,@Step)";
            
            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                _connection.Open();
                using (var tran = _connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRow = await _connection.ExecuteAsync(sql, model, transaction: tran);
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


        //public async Task<bool> UpdateUser(PostUserReq model)
        //{

        //}

        public async Task<bool> PostExperience(PostExperienceReq model)
        {
            bool result = false;

            string sql = @"INSERT INTO [dbo].[Experiences](Uid,Organization,Detail)
                          VALUES(@Uid,@Organization,@Detail)

                          UPDATE [dbo].[Users]
                          SET Step=@Step WHERE Uid=@Uid";
            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                _connection.Open();
                using (var tran = _connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRow = await _connection.ExecuteAsync(sql, model, transaction: tran);
                        if (affectedRow > 0)
                            result = true;
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message.ToString());
                    }
                    return result;
                }
            }
        }

        public async Task<User> QueryUserStepByIDNumberAndCellphone(QueryUserReq queryUserReq)
        {
            string sql = @"SELECT * FROM [dbo].[Users] 
                           WHERE IDNumber = @IDNumber 
                           AND Cellphone = @Cellphone";
            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, queryUserReq);
                if (entity == null)
                    return null;
                return entity;
            }
        }

        public async Task<IEnumerable<User>> GetUserAllDetail(User userReq)
        {
            string sql = @"SELECT * FROM [dbo].[Users] U
                           JOIN [dbo].[Experiences] E
                           ON U.Uid=E.Uid
                           JOIN [dbo].[Paintings] P
                           ON U.Uid=P.Uid
                           WHERE U.IDNumber = @IDNumber 
                           AND U.Cellphone = @Cellphone";
            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                var entity = await _connection.QueryAsync<User, Experience, Painting,User>(sql, (userReq,experience,painting)=>
                {
                    userReq.Experience = experience;
                    userReq.Painting = painting;
                    return userReq;
                },userReq,splitOn: "Uid");
                if (entity == null)
                    return null;
                return entity;
            }
        }

        public async Task<User> GetUserByUid(string uid)
        {
            string sql = @"SELECT * FROM [dbo].[Users] 
                           WHERE Uid = @Uid";
            using (IDbConnection _connection = new SqlConnection(_settings.Value.ConnectionSettings.UCFA_Conn))
            {
                var entity = await _connection.QuerySingleOrDefaultAsync<User>(sql, new { Uid=uid});
                if (entity == null)
                    return null;
                return entity;
            }
        }


    }
}
