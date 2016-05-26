using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using IqansAppsForCTS.Models;
using Microsoft.Ajax.Utilities;

namespace IqansAppsForCTS.DBMethods
{
    public class DbMethods
    {
        public static List<MeetingRoom> GetMeetingsByDate()
        {
            string dp = "System.Data.SqlClient";

            string cnStr = @"Data Source=.\sqlexpress;Initial Catalog=MeetingRoomManager;Integrated Security=True";
            //string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            try
            {
                using (DbConnection cn = df.CreateConnection())
                {
                    cn.ConnectionString = cnStr;
                    cn.Open();
                    DbCommand cmd = df.CreateCommand();

                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT * FROM Booking";
                    //cmd.Parameters.Add(new SqlParameter("@u", uname));
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        var listmr = new List<MeetingRoom>();
                        while (dr.Read())
                        {
                            var mr = new MeetingRoom();

                            mr.BookingId = dr["BookingId"].ToString();
                            mr.RoomNumber = dr["RoomNumber"].ToString();
                            mr.EmpId = (int)dr["EmpId"];
                            mr.EmpName = (dr["EmpName"] != null)? dr["EmpName"].ToString(): String.Empty;
                            mr.Subject = (dr["Subject"] != null) ? dr["Subject"].ToString() : String.Empty;
                            mr.StartDateTime = (DateTime) dr["StartDateTime"];
                            mr.EndDateTime = (DateTime)dr["EndDateTime"];
                            mr.Bookingtime = (DateTime)dr["Bookingtime"];
                            listmr.Add(mr);
                        }
                        return listmr;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static MeetingRoom Booking(MeetingRoom model)
        {
            //string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            string cnStr = @"Data Source=.\sqlexpress;Initial Catalog=MeetingRoomManager;Integrated Security=True";
            SqlConnection con = new SqlConnection(cnStr);
            SqlCommand cmd = null;

            try
            {
                con.Open();
                string sql = "INSERT INTO Booking (RoomNumber,EmpId,EmpName,Subject,StartDateTime,EndDateTime,Bookingtime)" +
                    "VALUES (@RoomNumber,@EmpId,@EmpName,@Subject,@StartDateTime,@EndDateTime,@Bookingtime)";
               
                cmd = new SqlCommand(sql, con);

                //cmd.Parameters.AddWithValue("@BookingId", model.BookingId);
                cmd.Parameters.AddWithValue("@RoomNumber", model.RoomNumber);
                cmd.Parameters.AddWithValue("@EmpId", model.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", model.EmpName);
                cmd.Parameters.AddWithValue("@Subject", model.Subject);
                cmd.Parameters.AddWithValue("@StartDateTime", model.StartDateTime);
                cmd.Parameters.AddWithValue("@EndDateTime", model.EndDateTime);
                cmd.Parameters.AddWithValue("@Bookingtime", model.Bookingtime);

                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }
                cmd = null;
               
                con.Close();
                return model;
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred. Error: " + e.Message);
            }
        }
    }
}