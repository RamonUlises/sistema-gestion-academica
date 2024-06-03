using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerContinuidad
    {
        public string RealizarReingreso(Clases.ClassReingreso reingreso)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "UPDATE datos_academicos SET id_grado = @grado, id_seccion = @seccion, " +
                        "id_turno = @turno, modalidad = @modalidad WHERE codigo_estudiante = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    int grado = new ControllerGrado().ObtenerIdGrado(reingreso.Grado);
                    int seccion = new ControllerSecciones().ObtenerIdSeccion(reingreso.Seccion);
                    int turno = new ControllerTurnos().ObtenerIdTurno(reingreso.Turno);
                    int modalidad = new ControllerModalidad().ObtenerIdModalidad(reingreso.Modalidad);

                    cmd.Parameters.AddWithValue("@grado", grado);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@turno", turno);
                    cmd.Parameters.AddWithValue("@codigo", reingreso.CodigoAlumno);
                    cmd.Parameters.AddWithValue("@modalidad", modalidad);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.RecordsAffected > 0)
                        {
                            return "Reingreso realizado con éxito";
                        }

                        return "No se pudo realizar el reingreso";
                    }
                }
            } catch (Exception ex)
            {
                return ex.Message;
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
