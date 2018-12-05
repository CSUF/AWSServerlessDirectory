namespace AWSServerlessDirectory.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using static System.Globalization.CultureInfo;
	using static System.Configuration.ConfigurationManager;
	using Newtonsoft.Json;
    using AWSServerlessDirectory.AWSConnection;

    [Route("api/[controller]")]
	public class ValuesController : Controller
	{
        //[HttpGet]
        //public IActionResult Get()
        //{
        //          string sqlCommandText = "SELECT TOP 10 [pl].[Office] FROM [dbo].[PhoneLine] [pl] WHERE LTRIM(RTRIM([office]))<>''";

        //	using (SqlConnection theSqlConn = new SqlConnection(connectionString: ProdMSSQL.GetSecret()))
        //	{
        //		theSqlConn.Open();
        //		DataTable queryResult = new DataTable();
        //		using (SqlCommand theSqlCommand = theSqlConn.CreateCommand())
        //		{
        //			theSqlCommand.CommandType = CommandType.Text;
        //			theSqlCommand.CommandText = sqlCommandText;
        //			queryResult.Load(reader: theSqlCommand.ExecuteReader(CommandBehavior.CloseConnection), loadOption: LoadOption.Upsert);
        //		}
        //		if (theSqlConn != null && theSqlConn.State != ConnectionState.Closed) theSqlConn.Close();
        //		if (queryResult.Rows.Count > 0)
        //		{
        //			List<string> result = new List<string>();
        //			foreach (DataRow item in queryResult.Rows) result.Add(Convert.ToString(item["office"], InvariantCulture));
        //			return Ok(result);
        //		}
        //		else
        //		{
        //			return NotFound();
        //		}
        //	}
        //}

        [Route("GetSearchKen")]
        public IActionResult GetSearchKen()
        {
            string sqlCommandText = "spx_Directory_People_Search";
            dynamic secretInstance = JsonConvert.DeserializeObject(ProdMSSQL.GetSecret());
            string connString = Convert.ToString(secretInstance.DBConnectionString);
            //return Ok(secretInstance.DBConnectionString);
            using (SqlConnection theSqlConn = new SqlConnection(connectionString: connString))
            {
                theSqlConn.Open();
                DataTable queryResult = new DataTable();
                using (SqlCommand theSqlCommand = theSqlConn.CreateCommand())
                {
                    theSqlCommand.CommandType = CommandType.StoredProcedure;
                    theSqlCommand.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "kly";
                    theSqlCommand.CommandText = sqlCommandText;
                    queryResult.Load(reader: theSqlCommand.ExecuteReader(CommandBehavior.CloseConnection), loadOption: LoadOption.Upsert);
                }
                if (theSqlConn != null && theSqlConn.State != ConnectionState.Closed) theSqlConn.Close();
                if (queryResult.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(queryResult));
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [Route("GetSearchAndy")]
        public IActionResult GetSearchAndy()
        {
            string sqlCommandText = "spx_Directory_People_Search";
            //List<string> secretInstance = JsonConvert.DeserializeObject<List<string>>(ProdMSSQL.GetSecret());
            dynamic secretInstance = JsonConvert.DeserializeObject(ProdMSSQL.GetSecret());
            string connString = Convert.ToString(secretInstance.DBConnectionString);
            //return Ok(secretInstance.DBConnectionString);
            using (SqlConnection theSqlConn = new SqlConnection(connectionString: connString))
            {
                theSqlConn.Open();
                DataTable queryResult = new DataTable();
                using (SqlCommand theSqlCommand = theSqlConn.CreateCommand())
                {
                    theSqlCommand.CommandType = CommandType.StoredProcedure;
                    theSqlCommand.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "andy";
                    theSqlCommand.CommandText = sqlCommandText;
                    queryResult.Load(reader: theSqlCommand.ExecuteReader(CommandBehavior.CloseConnection), loadOption: LoadOption.Upsert);
                }
                if (theSqlConn != null && theSqlConn.State != ConnectionState.Closed) theSqlConn.Close();
                if (queryResult.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(queryResult));
                }
                else
                {
                    return NotFound();
                }
            }
        }

        //[HttpGet("{userName}")]
        public IActionResult Get(string userName)
		{
			string sqlCommandText = "spx_Directory_People_Search";
            dynamic secretInstance = JsonConvert.DeserializeObject(ProdMSSQL.GetSecret());
            string connString = Convert.ToString(secretInstance.DBConnectionString);
            using (SqlConnection theSqlConn = new SqlConnection(connectionString: connString))
			{
				theSqlConn.Open();
				DataTable queryResult = new DataTable();
				using (SqlCommand theSqlCommand = theSqlConn.CreateCommand())
				{
					theSqlCommand.CommandType = CommandType.StoredProcedure;
					theSqlCommand.Parameters.Add("@Search", SqlDbType.NVarChar).Value = userName;
					theSqlCommand.CommandText = sqlCommandText;
					queryResult.Load(reader: theSqlCommand.ExecuteReader(CommandBehavior.CloseConnection), loadOption: LoadOption.Upsert);
				}
				if (theSqlConn != null && theSqlConn.State != ConnectionState.Closed) theSqlConn.Close();
				if (queryResult.Rows.Count > 0)
				{
					return Ok(JsonConvert.SerializeObject(queryResult));
				}
				else
				{
					return NotFound();
				}
			}
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
