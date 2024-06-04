using MySql.Data.MySqlClient;
using SGA.Connection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Controllers
{
    class ControllerDatosAcademicos
    {
        public string[] ObtenerDatosPorId (int id)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT codigo_estudiante, fecha_matricula, nivel_educativo, repitente, modalidad, id_grado, id_seccion, id_turno, id_centro FROM datos_academicos WHERE id_datos_academicos = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string codigo = reader["codigo_estudiante"].ToString();
                            string fecha = reader["fecha_matricula"].ToString();
                            string nivel = reader["nivel_educativo"].ToString();
                            string repitente = reader["repitente"].ToString();
                            string modalidad = new ControllerModalidad().ObtenerModalidadPorId(Convert.ToInt32(reader["modalidad"]));
                            string grado = new ControllerGrado().ObtenerGradoPorId(Convert.ToInt32(reader["id_grado"]));
                            string seccion = new ControllerSecciones().ObtenerSeccionPorId(Convert.ToInt32(reader["id_seccion"]));
                            string turno = new ControllerTurnos().ObtenerTurnoPorId(Convert.ToInt32(reader["id_turno"]));
                            string centro = new ControllerCentros().ObtenerCentroPorId(Convert.ToInt32(reader["id_centro"]));

                            return new string[] { codigo, fecha, nivel, repitente, modalidad, grado, seccion, turno, centro };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            } catch (Exception e)
            {
                return null;
            } finally
            {
                connection.CloseConnection();
            }
        }
        public string AgregarDatosAcademicos(Clases.ClassDatosAcademicos datosAcademicos, int idEstudiante)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "INSERT INTO datos_academicos (codigo_estudiante, fecha_matricula, nivel_educativo, repitente, modalidad, " +
                        "id_grado, id_seccion, id_turno, id_centro, id_estudiante) VALUES (@codigo, @fecha, @nivel, @repitente, @modalidad, @grado, @seccion, " +
                        "@turno, @centro, @estudiante)";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    DateTime fechaConvertida = DateTime.ParseExact(datosAcademicos.FechaMatricula, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string fechaSql = fechaConvertida.ToString("yyyy-MM-dd");

                    int repite = datosAcademicos.Repitente ? 1 : 0;
                    int modalidad = new ControllerModalidad().ObtenerIdModalidad(datosAcademicos.Modalidad);
                    int grado = new ControllerGrado().ObtenerIdGrado(datosAcademicos.Grado);
                    int seccion = new ControllerSecciones().ObtenerIdSeccion(datosAcademicos.Seccion);
                    int turno = new ControllerTurnos().ObtenerIdTurno(datosAcademicos.Turno);
                    int centro = new ControllerCentros().ObtenerIdCentro(datosAcademicos.NombreCentroEducativo);

                    cmd.Parameters.AddWithValue("@codigo", datosAcademicos.CodigoEstudiante);
                    cmd.Parameters.AddWithValue("@fecha", fechaSql);
                    cmd.Parameters.AddWithValue("@nivel", datosAcademicos.NivelEducativo);
                    cmd.Parameters.AddWithValue("@repitente", repite);
                    cmd.Parameters.AddWithValue("@modalidad", modalidad);
                    cmd.Parameters.AddWithValue("@grado", grado);
                    cmd.Parameters.AddWithValue("@seccion", seccion);
                    cmd.Parameters.AddWithValue("@turno", turno);
                    cmd.Parameters.AddWithValue("@centro", centro);
                    cmd.Parameters.AddWithValue("@estudiante", idEstudiante);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.RecordsAffected > 0)
                        {
                            return "Datos académicos agregados correctamente";
                        }
                        else
                        {
                            return "Error al agregar los datos académicos";
                        }
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
