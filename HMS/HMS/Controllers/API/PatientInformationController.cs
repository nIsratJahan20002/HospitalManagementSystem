using HMS.Models.HMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMS.Controllers.API
{
    [RoutePrefix("api/PatientInfo")]
    public class PatientInformationController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
        SqlCommand cmd;


        [HttpPost]
        [Route("Save")]
        public int Save(PatientInfo entity)
        {
            con.Open();

            cmd = new SqlCommand("Set_PatientInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientName", entity.PatientName);
            cmd.Parameters.AddWithValue("@CellNo", entity.CellNo);
            cmd.ExecuteNonQuery();

            con.Close();

            return 1;
    }
        [HttpGet]
        [Route("GetById")]
        public dynamic GetById(int PatientId)
        {
            var result = new List<PatientInfo>();
            con.Open();

            cmd = new SqlCommand("SpPatientInfoGetById '" + PatientId + "'", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    PatientInfo a = new PatientInfo();

                    a.PatientId = Convert.ToInt32(reader["PatientId"]);
                    a.PatientName = Convert.ToString(reader["PatientName"]);
                    a.CellNo = Convert.ToString(reader["CellNo"]);
                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }
        [HttpGet]
        [Route("GetAll")]
        public dynamic GetAll()
        {
            var result = new List<PatientInfo>();
            con.Open();

            cmd = new SqlCommand("GetAll_PatientInfo", con);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    PatientInfo a = new PatientInfo();

                    a.PatientId = Convert.ToInt32(reader["PatientId"]);
                    a.PatientName = Convert.ToString(reader["PatientName"]);
                    a.CellNo = Convert.ToString(reader["CellNo"]);

                    result.Add(a);
                }
            }

            con.Close();

            return result;
        }



        [HttpPost]
        [Route("Update")]
        public int Update(PatientInfo entity)
        {
            if (entity.DoctorId != 0)
            {
                con.Open();

                cmd = new SqlCommand("SpUPD_PatientInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PatientId", entity.PatientId);
                cmd.Parameters.AddWithValue("@PatientName", entity.PatientName);
                cmd.Parameters.AddWithValue("@CellNo", entity.CellNo);
                cmd.ExecuteNonQuery();

                con.Close();

                return 1;
            }
            else
            {
                return 0;
            }
        }


        //[HttpPost]
        //[Route("InActive")]
        //public dynamic InActive(int PatientId)
        //{
        //    con.Open();

        //    cmd = new SqlCommand("SpInActive_PatientInfo", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@PatientId", PatientId);
        //    cmd.ExecuteNonQuery();

        //    con.Close();

        //    return 1;
        //}
    }
}


