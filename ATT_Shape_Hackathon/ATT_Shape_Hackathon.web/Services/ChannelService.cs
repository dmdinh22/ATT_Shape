using ATT_Shape_Hackathon.web.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WikiDataProvider.Data.Extensions;

namespace ATT_Shape_Hackathon.web.Services
{
    public class ChannelService : BaseService
    {
        public List<Channel> Channel_SelectAll()
        {
            List<Channel> channel = new List<Channel>();
            DataProvider.ExecuteCmd(
                GetConnection,
                "Channel_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    Channel c = MapChannel(reader);
                    channel.Add(c);
                });
            return channel;
        } //Channel_SelectAll

        public Channel Channel_SelectById(int channelId)
        {
            Channel row = null;

            DataProvider.ExecuteCmd(
                GetConnection,
                "dbo.Channel_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ID", channelId);
                },
                map: delegate (IDataReader reader, short set)
                {
                    Channel c = MapChannel(reader);
                    if (row == null)
                    {
                        row = c;
                    }
                });
            return row;
        } //Channel_SelectById

        public Channel Channel_SelectByTitle(string channelTitle)
        {
            Channel row = null;

            DataProvider.ExecuteCmd(
                GetConnection,
                "dbo.Channel_SelectById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Title", channelTitle);
                },
                map: delegate (IDataReader reader, short set)
                {
                    Channel c = MapChannel(reader);
                    if (row == null)
                    {
                        row = c;
                    }
                });
            return row;
        } //Channel_SelectByTitle

        public int Channel_Insert(Channel c)
        {
            int i = 0;
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "Channel_Insert",
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

        public void Channel_UpdateById(Channel c)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "Channel_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", c.Id);
                    paramCollection.AddWithValue("@Title", c.Title);
                    paramCollection.AddWithValue("@Description", c.Description);
                    paramCollection.AddWithValue("@Active", c.Active);

                },
                returnParameters: null);
        } //Channel_UpdateById

        public void Channel_DeleteById(int id)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "Channel_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        } //Channel_DeleteById

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
    }
}