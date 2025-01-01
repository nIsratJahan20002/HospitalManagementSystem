using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using HMS.Models.HMS;

namespace HMS.Controllers.API
{
    [RoutePrefix("api/AssistantInfo")]
    public class AssistantInformationController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
        SqlCommand cmd;


        [HttpPost]
        [Route("Save")]
        public int Save(AssistantInfo entity)
        {
            con.Open();

            cmd = new SqlCommand("Set_AssistantInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AssistantName", entity.AssistantName);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
        }

        [HttpGet]
        [Route("GetAll")]
        public dynamic GetAll()
        {
            var result = new List<AssistantInfo>();
            con.Open();

            cmd = new SqlCommand("GetAll_AssistantInfo", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    AssistantInfo a = new AssistantInfo();

                    a.AssistantId = Convert.ToInt32(reader["AssistantId"]);
                    a.AssistantName = Convert.ToString(reader["AssistantName"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }

        [HttpGet]
        [Route("GetById")]
        public dynamic GetById(int AssistantId)
        {
            var result = new List<AssistantInfo>();
            con.Open();

            cmd = new SqlCommand("SpAssistantInfoGetById '" + AssistantId + "'", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    AssistantInfo a = new AssistantInfo();

                    a.AssistantId = Convert.ToInt32(reader["AssistantId"]);
                    a.AssistantName = Convert.ToString(reader["AssistantName"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }


        [HttpPost]
        [Route("Update")]
        public int Update(AssistantInfo entity)
        {
            if (entity.AssistantId != 0)
            {
                con.Open();

                cmd = new SqlCommand("SpUPD_AssistantInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssistantId", entity.AssistantId);
                cmd.Parameters.AddWithValue("@AssistantName", entity.AssistantName);
                cmd.ExecuteNonQuery();

                con.Close();

                return 1;
            }
            else
            {
                return 0;
            }
        }


        [HttpPost]
        [Route("InActive")]
        public dynamic InActive(int DoctorId)
        {
            con.Open();

            cmd = new SqlCommand("SpInActive_DoctorInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DoctorId", DoctorId);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
        }
    }
}
