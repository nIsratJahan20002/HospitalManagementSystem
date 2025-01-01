using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using HMS.Models.HMS;

namespace HMS.Controllers.API
{
    [RoutePrefix("api/DoctorInfo")]
    public class DoctorInformationController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
        SqlCommand cmd;


        [HttpPost]
        [Route("Save")]
        public int Save(DoctorInfo entity)
        {
            con.Open();

            cmd = new SqlCommand("Set_DoctorInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DoctorName", entity.DoctorName);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
        }

        [HttpGet]
        [Route("GetAll")]
        public dynamic GetAll()
        {
            var result = new List<DoctorInfo>();
            con.Open();

            cmd = new SqlCommand("GetAll_DoctorInfo", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DoctorInfo a = new DoctorInfo();

                    a.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                    a.DoctorName = Convert.ToString(reader["DoctorName"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }

        [HttpGet]
        [Route("GetById")]
        public dynamic GetById(int DoctorId)
        {
            var result = new List<DoctorInfo>();
            con.Open();

            cmd = new SqlCommand("SpDoctorInfoGetById '" + DoctorId + "'", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DoctorInfo a = new DoctorInfo();

                    a.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                    a.DoctorName = Convert.ToString(reader["DoctorName"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }


        [HttpPost]
        [Route("Update")]
        public int Update(DoctorInfo entity)
        {
            if (entity.DoctorId != 0)
            {
                con.Open();

                cmd = new SqlCommand("SpUPD_DoctorInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DoctorId", entity.DoctorId);
                cmd.Parameters.AddWithValue("@DoctorName", entity.DoctorName);
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
