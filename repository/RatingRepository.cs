using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly Store21Context _DbContext;

        public RatingRepository(Store21Context dbContext)
        {
            _DbContext = dbContext;
        }


       // string connectionString = "Data Source=srv2\\pupils;Initial Catalog=Store21;Integrated Security=True";
        public async Task post(Rating rating)
        {

          await  _DbContext.Ratings.AddAsync(rating);
          await   _DbContext.SaveChangesAsync();
            //string Query = "INSERT INTO RATING(HOST,METHOD,PATH ,REFERER ,USER_AGENT,Record_Date )" +
            //    "VALUES(@HOST,@METHOD,@PATH ,@REFERER ,@USER_AGENT,@Record_Date )";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(Query, connection))
            //{
            //    command.Parameters.Add("@HOST", SqlDbType.VarChar, 50).Value = rating.Host;
            //    command.Parameters.Add("@METHOD", SqlDbType.VarChar, 10).Value = rating.Method;
            //    command.Parameters.Add("@PATH", SqlDbType.VarChar, 50).Value = rating.Path;
            //    command.Parameters.Add("@REFERER", SqlDbType.VarChar, 100).Value = rating.Referer;
            //    command.Parameters.Add("@USER_AGENT", SqlDbType.VarChar, 100000).Value = rating.UserAgent;
            //    command.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;


            //    connection.Open();
            //    int rowsEfected= command.ExecuteNonQuery();
            //    connection.Close();

            //}
           
            }
    }
}
