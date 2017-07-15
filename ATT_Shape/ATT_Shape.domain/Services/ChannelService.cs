using ATT_Shape.domain.Classes;
using ATT_Shape.domain.Models.Request;
using ATT_Shape.domain.Services.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web;

namespace ATT_Shape.domain.Services
{
    public class ChannelService : BaseService
    {
        public List<Classes.Channel> Channel_SelectAll()
        {
            List<Channel> channel = null;

            DataProvider.Instance.ExecuteCmd(
                GetConnection,
                "dbo.Channel_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    if (channel == null)
                    {
                        channel = new List<Channel>();
                    }
                    channel.Add(DataMapper<Channel>.Instance.MapToObject(reader));
                });
            return channel;
        } //Channel_SelectAll

        public Channel Channel_SelectById(int channelId)
        {
            Channel row = null;

            DataProvider.Instance.ExecuteCmd(
                GetConnection,
                "dbo.Channel_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", channelId);
                },
                map: delegate (IDataReader reader, short set)
                {
                    if (row == null)
                    {
                        row = DataMapper<Channel>.Instance.MapToObject(reader);
                    }
                });
            return row;
        } //Channel_SelectById

        public Channel Channel_SelectByTitle(string channelTitle)
        {
            Channel row = null;

            DataProvider.Instance.ExecuteCmd(
                GetConnection,
                "dbo.Channel_SelectByTitle",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Title", channelTitle);
                },
                map: delegate (IDataReader reader, short set)
                {
                    if (row == null)
                    {
                        row = DataMapper<Channel>.Instance.MapToObject(reader);
                    }
                });
            return row;
        } //Channel_SelectByTitle

        public int Channel_Insert(Channel c)
        {
            int i = 0;
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "dbo.Channel_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Title", c.Title);
                    paramCollection.AddWithValue("@Description", c.Description);
                    paramCollection.AddWithValue("@Active", c.Active);

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    paramCollection.Add(param);
                },
                returnParameters: delegate (SqlParameterCollection paramCollection)
                {
                    int.TryParse(paramCollection["@Id"].Value.ToString(), out i);
                });
            return i;
        } //Channel_Insert

        public void Channel_InsertUserId(UserChannelRequest c)
        {
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "dbo.UserChannel_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@UserId", c.UserId);
                    paramCollection.AddWithValue("@ChannelId", c.ChannelId);

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    paramCollection.Add(param);
                }
                );
        } //Channel_Insert

        public void Channel_UpdateById(Channel c)
        {
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "dbo.Channel_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", c.Id);
                    paramCollection.AddWithValue("@Title", c.Title);
                    paramCollection.AddWithValue("@Description", c.Description);
                    paramCollection.AddWithValue("@Active", c.Active);

                },
                returnParameters: null);
            return;
        } //Channel_UpdateById

        public void Channel_DeleteById(int id)
        {
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "dbo.Channel_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        }
       
        //Channel_DeleteById

        /*
        private Channel MapChannel (IDataReader reader)
        {
            Channel c = new Channel();
            int startingIndex = 0;
            c.Id = reader.GetSafeInt32(startingIndex++);
            c.Title = reader.GetSafeString(startingIndex++);
            c.Description = reader.GetSafeString(startingIndex++);
            c.Active = reader.GetBoolean(startingIndex++);
            c.DateCreated = reader.GetSafeDateTime(startingIndex++);

            return c;
        } //MapChannel
        */
    }

   
}
