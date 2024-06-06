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
        public List<Clases.ClassGetEstudiantes> BuscarEstudiantesIndex(string busqueda)
        {
            DB_Connection connection = new DB_Connection();
            List<Clases.ClassGetEstudiantes> estudiantes = new List<Clases.ClassGetEstudiantes>();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    List<int> ids = ExtraerEstudiantesBusqueda(busqueda);

                    if (ids.Count == 0)
                    {
                        return estudiantes;
                    }

                    for (int i = 0; i < ids.Count; i++)
                    {
                        string query = "SELECT * FROM estudiantes WHERE id_estudiante = @id";
                        MySqlCommand cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@id", ids[i]);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            Clases.ClassGetEstudiantes estudiante = new Clases.ClassGetEstudiantes();

                            string nombres = reader["nombres"].ToString() + " " + reader["apellidos"].ToString();
                            string partidaNacimiento = reader["partida_nacimiento"].ToString();
                            string sexo = new ControllerSexos().ObtenerSexo(Convert.ToInt32(reader["id_sexo"].ToString()));
                            string pais = new ControllerPais().ObtenerPaisPorId(Convert.ToInt32(reader["id_pais"].ToString()));
                            string departamento = new ControllerDepartamentos().ObtenerDepartamentoPorId(Convert.ToInt32(reader["id_departamento"].ToString()));
                            string municipio = new ControllerMunicipios().ObtenerMunicipioPorId(Convert.ToInt32(reader["id_municipio"].ToString()));
                            string nacionalidad = new ControllerPais().ObtenerNacionalidadPorId(Convert.ToInt32(reader["id_nacionalidad"].ToString()));
                            string etnia = new ControllerEtnias().ObtenerEtniaPorId(Convert.ToInt32(reader["id_etnia"].ToString()));
                            string lengua = new ControllerLenguaMaterna().ObtenerLenguaPorId(Convert.ToInt32(reader["id_lengua"].ToString()));
                            string discapacidad = new ControllerDiscapacidad().ObtenerDiscapacidadPorId(Convert.ToInt32(reader["id_discapacidad"].ToString()));
                            string[] tutor = new ControllerTutorEstudiante().ObtenerDatosPorId(Convert.ToInt32(reader["id_tutor_x_estudiante"]));

                            bool poseeDatos = new ControllerDatosAcademicos().TieneDatos(Convert.ToInt32(reader["id_estudiante"]));

                            string codigoEstudiante = "No definido";
                            string FechaMatriculaAcademica = "No definido";
                            string nivelEducativo = "No definido";
                            bool repitente = false;
                            string modalidad = "No definido";
                            string grado = "No definido";
                            string seccion = "No definido";
                            string turno = "No definido";
                            string centroEducativo = "No definido";

                            if (poseeDatos == true)
                            {
                                string[] datosAcademicos = new ControllerDatosAcademicos().ObtenerDatosPorId(Convert.ToInt32(reader["id_estudiante"]));

                                codigoEstudiante = datosAcademicos[0];
                                FechaMatriculaAcademica = datosAcademicos[1];
                                nivelEducativo = datosAcademicos[2];
                                repitente = (datosAcademicos[3] == "1");
                                modalidad = datosAcademicos[4];
                                grado = datosAcademicos[5];
                                seccion = datosAcademicos[6];
                                turno = datosAcademicos[7];
                                centroEducativo = datosAcademicos[8];
                            }

                            estudiante.Id = Convert.ToInt32(reader["id_estudiante"]);
                            estudiante.Nombres = nombres;
                            estudiante.Cedula = reader["cedula"].ToString();
                            estudiante.FechaNacimiento = reader["fecha_nacimiento"].ToString();
                            estudiante.Direccion = reader["direccion"].ToString();
                            estudiante.Telefono = reader["telefono"].ToString();
                            estudiante.PartidaNacimiento = (partidaNacimiento == "1");
                            estudiante.FechaMatricula = reader["fecha_matricula"].ToString();
                            estudiante.Barrio = reader["barrio"].ToString();
                            estudiante.Peso = Convert.ToDouble(reader["peso"]);
                            estudiante.Talla = Convert.ToDouble(reader["talla"]);
                            estudiante.TerritorioIndigena = reader["territorio_indigena"].ToString();
                            estudiante.ComunidadIndigena = reader["comunidad_indigena"].ToString();
                            estudiante.Sexo = sexo;
                            estudiante.Pais = pais;
                            estudiante.Departamento = departamento;
                            estudiante.Municipio = municipio;
                            estudiante.Nacionalidad = nacionalidad;
                            estudiante.Etnia = etnia;
                            estudiante.LenguaMaterna = lengua;
                            estudiante.Discapacidad = discapacidad;
                            estudiante.NombresTutor = tutor[0];
                            estudiante.CedulaTutor = tutor[1];
                            estudiante.TelefonoTutor = tutor[2];
                            estudiante.CodigoEstudiante = codigoEstudiante;
                            estudiante.FechaMatriculaAcademica = FechaMatriculaAcademica;
                            estudiante.NivelEducativo = nivelEducativo;
                            estudiante.Repitente = repitente;
                            estudiante.Modalidad = modalidad;
                            estudiante.Grado = grado;
                            estudiante.Seccion = seccion;
                            estudiante.Turno = turno;
                            estudiante.CentroEducativo = centroEducativo;

                            estudiantes.Add(estudiante);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                return estudiantes;
            }
            finally
            {
                connection.CloseConnection();
            }

            return estudiantes;
        }

        public List<int> ExtraerEstudiantesBusqueda(string busqueda)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_estudiante FROM datos_academicos WHERE codigo_estudiante " +
                        "LIKE LOWER(CONCAT('%', @busqueda, '%'))";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@busqueda", busqueda);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<int> ids = new List<int>();
                        while (reader.Read())
                        {
                            ids.Add(Convert.ToInt32(reader["id_estudiante"]));
                        }
                        return ids;
                    }
                }
            }
            catch (Exception e)
            {
                return new List<int>();
            }
            finally
            {
                connection.CloseConnection();
            }
        }
        public bool TieneDatos(int id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT * FROM datos_academicos WHERE id_estudiante = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
        public string[] ObtenerDatosPorId(int id)
        {
            DB_Connection connection = new DB_Connection();
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT codigo_estudiante, fecha_matricula, nivel_educativo, repitente, modalidad, id_grado, id_seccion, id_turno, id_centro FROM datos_academicos WHERE id_estudiante = @id";
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
            }
            catch (Exception e)
            {
                return null;
            }
            finally
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
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
    }
}
