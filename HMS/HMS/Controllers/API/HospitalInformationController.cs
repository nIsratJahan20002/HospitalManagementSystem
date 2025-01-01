using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using HMS.Models.HMS;

namespace HMS.Controllers.API
{
    [RoutePrefix("api/HospitalInfo")]
    public class HospitalInformationController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
        SqlCommand cmd;


        [HttpPost]
        [Route("Save")]
        public int Save(HospitalInfo entity)
        {
            con.Open();

            cmd = new SqlCommand("Set_HospitalInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HospitalName", entity.HospitalName);
            cmd.Parameters.AddWithValue("@Address", entity.Address);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
        }

        [HttpGet]
        [Route("GetAll")]
        public dynamic GetAll()
        {
            var result = new List<HospitalInfo>();
            con.Open();

            cmd = new SqlCommand("GetAll_HospitalInfo", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    HospitalInfo a = new HospitalInfo();

                    a.HospitalId = Convert.ToInt32(reader["HospitalId"]);
                    a.HospitalName = Convert.ToString(reader["HospitalName"]);
                    a.Address = Convert.ToString(reader["Address"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }

        [HttpGet]
        [Route("GetById")]
        public dynamic GetById(int HospitalId)
        {
            var result = new List<HospitalInfo>();
            con.Open();

            cmd = new SqlCommand("SpHospitalInfoGetById '" + HospitalId + "'", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    HospitalInfo a = new HospitalInfo();

                    a.HospitalId = Convert.ToInt32(reader["HospitalId"]);
                    a.HospitalName = Convert.ToString(reader["HospitalName"]);
                    a.Address = Convert.ToString(reader["Address"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }


        [HttpPost]
        [Route("Update")]
        public int Update(HospitalInfo entity)
        {
            if (entity.HospitalId != 0)
            {
                con.Open();

                cmd = new SqlCommand("SpUPD_HospitalInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HospitalId", entity.HospitalId);
                cmd.Parameters.AddWithValue("@HospitalName", entity.HospitalName);
                cmd.Parameters.AddWithValue("@Address", entity.Address);
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
        public dynamic InActive(int HospitalId)
        {
            con.Open();

            cmd = new SqlCommand("SpInActive_HospitalInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HospitalId", HospitalId);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
        }
    }
}
