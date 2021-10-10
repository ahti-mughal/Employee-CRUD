﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Web_CRUD_Application
{
    public class dbcon
    {
        SqlConnection con;
        public dbcon(string connectionstring)
        {
            connection(connectionstring);
        }
        public void connection(string connectionstring)
        {
            con = new SqlConnection(connectionstring);
        }
        public bool UDI(string query)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            bool check = cmd.ExecuteNonQuery() > 0;
            con.Close();
            return check;
        }
        public DataTable search(string query)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Close();
            return dt;
        }
    }
}