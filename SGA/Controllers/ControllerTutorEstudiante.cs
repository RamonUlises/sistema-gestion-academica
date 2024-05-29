using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace SGA.Controllers
{
    class ControllerTutorEstudiante
    {
        public int AgregarTutor (Clases.ClassEstudiantes tutor)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string[] nombresYApellidos = tutor.NombresTutor.Split(' ');
                    string nombres = nombresYApellidos[0] + " " + nombresYApellidos[1];
                    string apellidos = nombresYApellidos[2] + " " + nombresYApellidos[3];

                    string query = "INSERT INTO tutor_x_estudiante (nombres, apellidos, cedula, telefono, ) VALUES" +
                        " ('" + nombres + ", " + apellidos + ", " + tutor.CedulaTutor + "', '" + tutor.TelefonoTutor + "', '";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    
                    int idGenerado = Convert.ToInt32(cmd.ExecuteScalar());

                    return idGenerado;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }
        }



        public int ValidarTutor (Clases.ClassEstudiantes tutor)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT * FROM tutor_x_estudiante WHERE cedula = '" + tutor.CedulaTutor + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                     if (count > 0)
                    {
                        return BuscarTutor(tutor.CedulaTutor);
                        
                    }

                     int idTutor = AgregarTutor(tutor);
                    return idTutor;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }

        }
        public int BuscarTutor (string cedula)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT * FROM tutor_x_estudiante WHERE cedula = '" + cedula + "'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return int.Parse(reader["id_tutor_x_estudiante"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                connection.CloseConnection();
            }
        }

      
    }
}
