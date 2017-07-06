using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ATT_Shape.domain.Services.Data;
using ATT_Shape.domain.Classes;


namespace ATT_Shape.domain.Services
{
    public class LoggerService
    {
        /// <summary>
        /// Method used for returning the connnection string from the web.config or app.config
        /// </summary>
        /// <returns>SqlConnection</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        public static void Insert(System.Exception ex)
        {
            string apiUrl = DataHelper.GetApiUrl();
            string viewUrl = DataHelper.GetViewUrl();
            string body = DataHelper.GetBody();

            DataProvider.Instance.ExecuteNonQuery(
                GetConnection
                , "dbo.ExceptionLog_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Message", ex.Message.ToString());
                    paramCollection.AddWithValue("@Type", ex.GetType().Name.ToString());
                    paramCollection.AddWithValue("@ApiUrl", apiUrl);
                    paramCollection.AddWithValue("@ViewUrl", viewUrl);
                    paramCollection.AddWithValue("@RequestBody", body);

                    if (ex.StackTrace != null)
                    {
                        paramCollection.AddWithValue("@StackTrace", ex.StackTrace.ToString());
                    }
                    else
                    {
                        paramCollection.AddWithValue("@StackTrace", String.Empty);
                    }
                }
                , returnParameters: null
               );
            return;
        }
        public static List<Classes.Exception> SelectAll(out int totalResults)
        {
            List<Classes.Exception> list = null;
            int totalRows = 0;

            DataProvider.Instance.ExecuteCmd(
                GetConnection
                , "dbo.ExceptionLog_SelectAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    switch (set)
                    {
                        case 0:
                            if (list == null)
                            {
                                list = new List<Classes.Exception>();
                            }
                            list.Add(DataMapper<Classes.Exception>.Instance.MapToObject(reader));
                            break;
                    }
                }
               );
            totalResults = totalRows;
            return list;
        }
        //public static List<Domain.Exception> Search(ExceptionSearchRequest request, out int totalResults)
        //{
        //    List<Domain.Exception> list = null;
        //    int totalRows = 0;

        //    DataProvider.ExecuteCmd(GetConnection, "dbo.ExceptionLog_Search",
        //       inputParamMapper: delegate (SqlParameterCollection paramCollection)
        //       {
        //           paramCollection.AddWithValue("@Type", request.Type ?? String.Empty);
        //           paramCollection.AddWithValue("@Message", request.Message ?? String.Empty);
        //           paramCollection.AddWithValue("@StackTrace", request.StackTrace ?? String.Empty);
        //           paramCollection.AddWithValue("@Url", request.Url ?? String.Empty);
        //           paramCollection.AddWithValue("@Person", request.Person ?? String.Empty);
        //           paramCollection.AddWithValue("@StartDate", request.StartDate);
        //           paramCollection.AddWithValue("@EndDate", request.EndDate);
        //           paramCollection.AddWithValue("@CurrentPage", request.CurrentPage);
        //           paramCollection.AddWithValue("@ItemsPerPage", request.ItemsPerPage);
        //       },
        //       map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
        //       {
        //           switch (set)
        //           {
        //               case 0:
        //                   Domain.Exception ex = MapException(reader, out totalRows);

        //                   if (list == null)
        //                   {
        //                       list = new List<Domain.Exception>();
        //                   }
        //                   list.Add(ex);
        //                   break;
        //           }
        //       }
        //       );
        //    totalResults = totalRows;
        //    return list;
        //}

    }
}
