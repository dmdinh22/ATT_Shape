using ATT_Shape.domain.Models.Request;
using ATT_Shape.domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT_Shape.domain.Services
{
    public class VideoService : BaseService
    {
        public static int Insert(VideoAddRequest v)
        {
            int i = 0;
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection
                , "dbo.Video_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Title", v.Title);
                    paramCollection.AddWithValue("@Description", v.Description);
                    paramCollection.AddWithValue("@Url", v.Url);

                    SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    paramCollection.Add(param);
                },
                returnParameters: delegate (SqlParameterCollection paramCollection)
                {
                    int.TryParse(paramCollection["@Id"].Value.ToString(), out i);
                });
            return i;
        }
        public static List<Classes.Video> SelectAll()
        {
            List<Classes.Video> vList = null;

            DataProvider.Instance.ExecuteCmd(
                GetConnection
                , "dbo.Video_SelectAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    if (vList == null)
                    {
                        vList = new List<Classes.Video>();
                    }
                    vList.Add(DataMapper<Classes.Video>.Instance.MapToObject(reader));
                }
               );
            return vList;
        }
        public static Classes.Video Select(int id)
        {
            Classes.Video v = null;

            DataProvider.Instance.ExecuteCmd(
                GetConnection
                , "dbo.Video_SelectById"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    if (v == null)
                    {
                        v = DataMapper<Classes.Video>.Instance.MapToObject(reader);
                    }
                }
               );
            return v;
        }
        public static void Update(VideoUpdateRequest v)
        {
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection
                , "dbo.Video_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", v.Id);
                    paramCollection.AddWithValue("@Title", v.Title);
                    paramCollection.AddWithValue("@Description", v.Description);
                    paramCollection.AddWithValue("@Url", v.Url);
                }
                , returnParameters: null
               );
            return;
        }
        public static void Delete(int id)
        {
            DataProvider.Instance.ExecuteNonQuery(
                GetConnection,
                "dbo.Video_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        }
    }
}
