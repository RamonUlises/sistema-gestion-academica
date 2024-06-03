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
    class ControllerEstudiante
    {
        public string obtenerNombresEstudiante(int id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT nombres, apellidos FROM estudiantes WHERE id_estudiante = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        string nombres = "";
                        string apellidos = "";

                        reader.Read();
                        nombres = reader["nombres"].ToString();
                        apellidos = reader["apellidos"].ToString();

                        return nombres + " " + apellidos;

                    }
                }
            } catch (Exception)
            {
                return "";
            } finally
            {
                connection.CloseConnection();
            }
        }
        public string ObtenerDatosEstudiante(string id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT id_estudiante FROM datos_academicos WHERE codigo_estudiante = @id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        
                        if(!reader.HasRows)
                        {
                            return "Estudiante no encontrado";
                        }

                        int idEstudiante = int.Parse(reader["id_estudiante"].ToString());

                        return obtenerNombresEstudiante(idEstudiante);
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
        public string AgregarEstudinante(Clases.ClassEstudiantes estudiante)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    ControllerPais controllerPaises = new ControllerPais();
                    ControllerDepartamentos controllerDepartamentos = new ControllerDepartamentos();
                    ControllerMunicipios controllerMunicipios = new ControllerMunicipios();
                    ControllerEtnias controllerEtnias = new ControllerEtnias();
                    ControllerLenguaMaterna controllerLenguaMaterna = new ControllerLenguaMaterna();
                    ControllerDiscapacidad controllerDiscapacidad = new ControllerDiscapacidad();
                    ControllerTutorEstudiante controllerTutorEstudiante = new ControllerTutorEstudiante();

                    // Asegúrate de que las propiedades de tipo string no sean null
                    string nombres = estudiante.Nombre1 + " " + estudiante.Nombre2;
                    string apellidos = estudiante.Apellido1 + " " + estudiante.Apellido2;
                    string cedula = estudiante.Cedula == "" || estudiante.Cedula == null ? "000-000000-0000X" : estudiante.Cedula;
                    string telefono = estudiante.Telefono ?? string.Empty;
                    string territorioIndigena = estudiante.TerritorioIndigena ?? string.Empty;
                    string comunidadIndigena = estudiante.ComunidadIndigena ?? string.Empty;

                    bool resEstudent = ValidarEstudiante(cedula);

                    if (resEstudent)
                    {
                        return "La cédula del estudiantes ya se encuentra registrada";
                    }

                    int idSexo = (estudiante.Sexo == "Masculino") ? 1 : 2;

                    int idPais = controllerPaises.ObtenerPaisPorNombre(estudiante.Pais);
                    int idDepartamento = controllerDepartamentos.ObtenerIdDepartamento(estudiante.Departamento);
                    int idMunicipio = controllerMunicipios.ObtenerIdMunicipio(estudiante.Municipio);
                    int idNacionalidad = controllerPaises.ObtenerIdNacionalidad(estudiante.Nacionalidad);
                    int idEtnia = controllerEtnias.ObtenerIdEtnia(estudiante.Etnia);
                    int idLengua = controllerLenguaMaterna.ObtenerIdLengua(estudiante.Lengua);
                    int idDiscapacidad = controllerDiscapacidad.ObtenerIdDiscapacidad(estudiante.Discapacidad);
                    int idTutor = controllerTutorEstudiante.ValidarTutor(estudiante);

                    if(idTutor == 0)
                    {
                        return "La cédula del tutor ya se encuentra registrada con diferentes nombres";
                    }

                    DateTime fechaConvertida = DateTime.ParseExact(estudiante.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string fechaSql = fechaConvertida.ToString("yyyy-MM-dd");

                    int idPartida = estudiante.PartidaNacimiento ? 1 : 0;

                    DateTime fechaMatriculaConvertida = DateTime.ParseExact(estudiante.FechaMatricula, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string fechaMatriculaSql = fechaMatriculaConvertida.ToString("yyyy-MM-dd");

                    string query = "INSERT INTO estudiantes (nombres, apellidos, cedula, fecha_nacimiento, direccion, telefono, partida_nacimiento, fecha_matricula," +
                                   " barrio, peso, talla, territorio_indigena, comunidad_indigena, id_sexo, id_pais, id_departamento, id_municipio, id_nacionalidad, id_etnia, " +
                                   "id_lengua, id_discapacidad, id_tutor_x_estudiante) " +
                                   "VALUES (@nombres, @apellidos, @cedula, @fecha_nacimiento, @direccion, @telefono, @partida_nacimiento, @fecha_matricula, @barrio, " +
                                   "@peso, @talla, @territorio_indigena, @comunidad_indigena, @id_sexo, @id_pais, @id_departamento, @id_municipio, @id_nacionalidad, @id_etnia, " +
                                   "@id_lengua, @id_discapacidad, @id_tutor_x_estudiante)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Añadir parámetros
                    cmd.Parameters.AddWithValue("@nombres", nombres);
                    cmd.Parameters.AddWithValue("@apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaSql);
                    cmd.Parameters.AddWithValue("@direccion", estudiante.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@partida_nacimiento", idPartida);
                    cmd.Parameters.AddWithValue("@fecha_matricula", fechaMatriculaSql);
                    cmd.Parameters.AddWithValue("@barrio", estudiante.Barrio);
                    cmd.Parameters.AddWithValue("@peso", estudiante.Peso);
                    cmd.Parameters.AddWithValue("@talla", estudiante.Talla);
                    cmd.Parameters.AddWithValue("@territorio_indigena", territorioIndigena);
                    cmd.Parameters.AddWithValue("@comunidad_indigena", comunidadIndigena);
                    cmd.Parameters.AddWithValue("@id_sexo", idSexo);
                    cmd.Parameters.AddWithValue("@id_pais", idPais);
                    cmd.Parameters.AddWithValue("@id_departamento", idDepartamento);
                    cmd.Parameters.AddWithValue("@id_municipio", idMunicipio);
                    cmd.Parameters.AddWithValue("@id_nacionalidad", idNacionalidad);
                    cmd.Parameters.AddWithValue("@id_etnia", idEtnia);
                    cmd.Parameters.AddWithValue("@id_lengua", idLengua);
                    cmd.Parameters.AddWithValue("@id_discapacidad", idDiscapacidad);
                    cmd.Parameters.AddWithValue("@id_tutor_x_estudiante", idTutor);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return "Estudiante agregado correctamente";
                    }
                    else
                    {
                        return "No se pudo agregar el estudiante";
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

        public bool ValidarEstudiante(string cedula)
        {
            DB_Connection connection = new DB_Connection();

            if(cedula == "000-000000-0000X")
            {
                return false;
            }

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT * FROM estudiantes WHERE cedula = @cedula";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cedula", cedula);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return true;
                        }

                        return false;
                    }
                }
            } catch (Exception)
            {
                return false;
            } finally
            {
                connection.CloseConnection();
            }
        }
    }
}
