﻿using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerLenguaMaterna
    {
        public string[] ObtenerLenguas()
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT lengua FROM lenguas";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<string> lenguas = new List<string>();
                        while (reader.Read())
                        {
                            lenguas.Add(reader["lengua"].ToString());
                        }
                        return lenguas.ToArray();
                    }
                }   
            } catch (Exception e)
            {
                return new string[] {};
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
