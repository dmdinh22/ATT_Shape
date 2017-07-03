using ATT_Shape_Hackathon.web.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WikiDataProvider.Data.Extensions;
using WikiDataProvider.Data.Interfaces;

namespace ATT_Shape_Hackathon.web.Services
{
    public class PeopleService
    {
        public List<Person> SelectAll()
        {
            List<Person> people = new List<Person>();
            DataProvider.ExecuteCmd(
                GetConnection,
                "People_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    Person p = MapPerson(reader);
                    people.Add(p);
                });
            return people;
        }

        public int Insert(Person p)
        {
            int i = 0;
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "People_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@FirstName", p.FirstName);
                    paramCollection.AddWithValue("@LastName", p.LastName);

                    if (p.MiddleInitial.HasValue)
                        paramCollection.AddWithValue("@MiddleInitial", p.MiddleInitial.Value);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    paramCollection.Add(parm);
                },
                returnParameters: delegate (SqlParameterCollection paramCollection)
                {
                    int.TryParse(paramCollection["@Id"].Value.ToString(), out i);
                });
            return i;
        }

        public void Update(Person p)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "People_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", p.Id);
                    paramCollection.AddWithValue("@FirstName", p.FirstName);
                    paramCollection.AddWithValue("@LastName", p.LastName);

                    if (p.MiddleInitial.HasValue)
                        paramCollection.AddWithValue("@MiddleInitial", p.MiddleInitial.Value);
                },
                returnParameters: null);
        }

        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "People_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        }

        private Person MapPerson(IDataReader reader)
        {
            Person p = new Person();
            int startingIndex = 0;
            p.Id = reader.GetSafeInt32(startingIndex++);
            p.FirstName = reader.GetSafeString(startingIndex++);
            p.LastName = reader.GetSafeString(startingIndex++);

            string s = reader.GetSafeString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(s))
                p.MiddleInitial = s[0];

            return p;
        }

        // Alternatively, create a BaseService class
        // add this method to the base class
        protected static IDao DataProvider
        {
            get { return WikiDataProvider.Data.DataProvider.Instance; }
        }

        // Alternatively, create a BaseService class
        // add this method to the base class
        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}