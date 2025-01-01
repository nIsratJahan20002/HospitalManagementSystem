using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using HMS.Models.HMS;

namespace HMS.Controllers.API
{
    [RoutePrefix("api/ScheduleCreate")]
    public class ScheduleCreateController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
        SqlCommand cmd;

        [HttpGet]
        [Route("GetAll")]
        public dynamic GetAll()
        {
            var result = new List<GetScheduleCreate>();
            con.Open();

            cmd = new SqlCommand("GetAll_ScheduleInfo", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    GetScheduleCreate a = new GetScheduleCreate();

                    a.ScheduleId = Convert.ToInt32(reader["ScheduleId"]);
                    a.HospitalName = Convert.ToString(reader["HospitalName"]);
                    a.DoctorName = Convert.ToString(reader["DoctorName"]);
                    a.ScheduleDateTime = Convert.ToDateTime(reader["ScheduleDateTime"]);
                    a.Active = Convert.ToInt32(reader["Active"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }

        [HttpGet]
        [Route("GetHospitals")]
        public dynamic GetHospitals()
        {
            var result = new List<GetHospital>();
            con.Open();

            cmd = new SqlCommand("GetHospitals", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    GetHospital a = new GetHospital();

                    a.HospitalId = Convert.ToInt32(reader["HospitalId"]);
                    a.HospitalName = Convert.ToString(reader["HospitalName"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }

        [HttpGet]
        [Route("GetDoctors")]
        public dynamic GetDoctors()
        {
            var result = new List<DoctorInfo>();
            con.Open();

            cmd = new SqlCommand("GetDoctors", con);

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
        [Route("Save")]
        public int Save(ScheduleCreate entity)
        {
            con.Open();

            cmd = new SqlCommand("Set_ScheduleCreate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HospitalId", entity.HospitalId);
            cmd.Parameters.AddWithValue("@DoctorId", entity.DoctorId);
            cmd.Parameters.AddWithValue("@Active", entity.Active);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
        }
    }
}
