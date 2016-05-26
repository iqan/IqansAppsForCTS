using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using IqansAppsForCTS.Models;

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
                    cmd.CommandText = "SELECT * FROM Bookings";
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

        public MeetingRoom Booking(MeetingRoom model)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cnStr);
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            List<string> ls = new List<string>();

            try
            {
                con.Open();
                string sql = "INSERT INTO Users (LoginId,Password,FirstName,LastName,Role,Age,Gender,PhoneNumber,Email,Address,ZipCode,City,State,Country)" +
                    "VALUES (@l,@p,@f,@ln,@r,@a,@g,@c,@e,@ad,@z,@city,@state,@country)";
                string sql2 = "INSERT INTO Login (LoginId,Password)" +
                        "VALUES (@l,@p)";

                cmd = new SqlCommand(sql, con);
                cmd2 = new SqlCommand(sql2, con);
                string pre = string.Empty;
                if (model.Role == "IM")
                {
                    pre = "im_";
                }
                else
                {
                    pre = "us_";
                }

                string UserName1 = pre + model.FirstName;

                string UserName = CheckDuplicate(UserName1);

                cmd.Parameters.AddWithValue("@l", UserName);
                cmd.Parameters.AddWithValue("@p", model.Password);
                cmd.Parameters.AddWithValue("@f", model.FirstName);
                cmd.Parameters.AddWithValue("@ln", model.LastName);
                cmd.Parameters.AddWithValue("@r", model.Role);
                cmd.Parameters.AddWithValue("@a", model.Age);
                cmd.Parameters.AddWithValue("@g", model.Gender);
                cmd.Parameters.AddWithValue("@c", model.ContactNumber);
                cmd.Parameters.AddWithValue("@e", model.Email);
                cmd.Parameters.AddWithValue("@ad", model.Address);
                cmd.Parameters.AddWithValue("@z", model.ZipCode);
                cmd.Parameters.AddWithValue("@city", model.City);
                cmd.Parameters.AddWithValue("@state", model.State);
                cmd.Parameters.AddWithValue("@country", model.Country);
                cmd2.Parameters.AddWithValue("@l", UserName);
                cmd2.Parameters.AddWithValue("@p", model.Password);

                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }
                cmd = null;
                using (cmd2)
                {
                    //cmd2.ExecuteNonQuery();
                }
                cmd = null;
                con.Close();
                ls.Add(UserName);
                ls.Add("RegisterSuccess");
                return ls;
            }
            catch
            {
                ls.Add("");
                ls.Add("Register");
                return ls;
            }
        }
    }
}