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
    class ControllerTraslados
    {
        public string BorrarTraslado(string id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "DELETE FROM traslados WHERE codigo_estudiante = @id";


                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAfeccted = cmd.ExecuteNonQuery();

                    if (rowsAfeccted > 0)
                    {
                        return "Eliminado";
                    }
                    return "Error";
                }
            }
            catch
            {
                return "Error";
            }
            finally
            {
                connection.CloseConnection();
            }
        }
        public string AgregarTraslado(Clases.ClassTraslado traslado)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "INSERT INTO traslados (codigo_estudiante, motivo_traslado, fecha_traslado, id_centro, " +
                        "id_periodo, id_estudiante) VALUES (@codigo_estudiante, @traslado, @fecha, @centro, @periodo, @estudiante)";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    DateTime fechaConvertida = DateTime.ParseExact(traslado.FechaTraslado, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string fechaSql = fechaConvertida.ToString("yyyy-MM-dd");

                    int centro = new ControllerCentros().ObtenerIdCentro(traslado.CentroOrigen);
                    int periodo = new ControllerPeriodos().ObtenerIdPeriodo(traslado.PeriodoTraslado);
                    int estudiante = new ControllerEstudiante().ObtenerIdPorCodigo(traslado.CodigoEstudiante);

                    cmd.Parameters.AddWithValue("@codigo_estudiante", traslado.CodigoEstudiante);
                    cmd.Parameters.AddWithValue("@traslado", traslado.MotivoTraslado);
                    cmd.Parameters.AddWithValue("@fecha", fechaSql);
                    cmd.Parameters.AddWithValue("@centro", centro);
                    cmd.Parameters.AddWithValue("@periodo", periodo);
                    cmd.Parameters.AddWithValue("@estudiante", estudiante);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.RecordsAffected > 0)
                        {
                            return "Traslado agregado correctamente";
                        }
                        else
                        {
                            return "Error al agregar el traslado";
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
