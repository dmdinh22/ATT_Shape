using ATT_Shape3.web.Models;
using ATT_Shape3.web.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WikiDataProvider.Data.Extensions;

namespace ATT_Shape_Hackathon.web.Services
{
    public class PeopleService : BaseService
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
        } //SelectAll

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
        } //Insert

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
        } //Update

        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "People_DeleteById",
                inputParamMapper: delegate (SqlParameterCollection paramCollection) {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        } //Delete

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
        } //MapPerson

    }
}