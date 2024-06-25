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
        public string EditarEstudiante(Clases.ClassEstudiantes estudiante, Clases.ClassDatosAcademicos datos, int id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                if(estudiante.Nombre1 == "No editar")
                {
                    string response = new ControllerDatosAcademicos().EditarDatosAcademicos(datos, id);
                    return response;
                }
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
                    string territorioIndigena = (estudiante.TerritorioIndigena != "") ? estudiante.TerritorioIndigena : "Ninguna";
                    string comunidadIndigena = (estudiante.ComunidadIndigena != "") ? estudiante.ComunidadIndigena : "Ninguna";

                    int idSexo = (estudiante.Sexo == "Masculino") ? 1 : 2;

                    int idPais = controllerPaises.ObtenerPaisPorNombre(estudiante.Pais);
                    int idDepartamento = controllerDepartamentos.ObtenerIdDepartamento(estudiante.Departamento);
                    int idMunicipio = controllerMunicipios.ObtenerIdMunicipio(estudiante.Municipio);
                    int idNacionalidad = controllerPaises.ObtenerIdNacionalidad(estudiante.Nacionalidad);
                    int idEtnia = controllerEtnias.ObtenerIdEtnia(estudiante.Etnia);
                    int idLengua = controllerLenguaMaterna.ObtenerIdLengua(estudiante.Lengua);
                    int idDiscapacidad = controllerDiscapacidad.ObtenerIdDiscapacidad(estudiante.Discapacidad);

                    DateTime fechaConvertida = DateTime.ParseExact(estudiante.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    string fechaSql = fechaConvertida.ToString("yyyy-MM-dd");

                    int idPartida = estudiante.PartidaNacimiento ? 1 : 0;

                    string query = "UPDATE estudiantes SET nombres = @nombres, apellidos = @apellidos, cedula = @cedula, fecha_nacimiento = @fecha_nacimiento, direccion = @direccion, " +
                                   "telefono = @telefono, partida_nacimiento = @partida_nacimiento, barrio = @barrio, peso = @peso, talla = @talla, " +
                                   "territorio_indigena = @territorio_indigena, comunidad_indigena = @comunidad_indigena, id_sexo = @id_sexo, id_pais = @id_pais, id_departamento = @id_departamento, " +
                                   "id_municipio = @id_municipio, id_nacionalidad = @id_nacionalidad, id_etnia = @id_etnia, id_lengua = @id_lengua, id_discapacidad = @id_discapacidad " +
                                   "WHERE id_estudiante = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Añadir parámetros
                    cmd.Parameters.AddWithValue("@nombres", nombres);
                    cmd.Parameters.AddWithValue("@apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@fecha_nacimiento", fechaSql);
                    cmd.Parameters.AddWithValue("@direccion", estudiante.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@partida_nacimiento", idPartida);
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
                    cmd.Parameters.AddWithValue("@id", id);
                        
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string resss = new ControllerDatosAcademicos().EditarDatosAcademicos(datos, id);
                        return resss;
                    }
                    else
                    {
                        return "No se actualizó el estudiante";
                    }
                } 
            } catch (Exception ex)
            {
                return ex.ToString();
            } finally
            {
                connection.CloseConnection();
            }
        }
        public string BorrarEstudiante(int id)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using(MySqlConnection con = connection.GetConnection())
                {
                    string query = "DELETE FROM estudiantes WHERE id_estudiante = @id";


                    MySqlCommand cmd =  new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAfeccted = cmd.ExecuteNonQuery();

                    if(rowsAfeccted  > 0)
                    {
                        return "Eliminado";
                    }
                    return "Error";
                }
            } catch
            {
                return "Error";
            } finally
            {
                connection.CloseConnection();
            }
        }
        public List<int> BuscarEstudiantesIndex(string busqueda)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    List<int> ids = new List<int>();

                    string query = "SELECT id_estudiante FROM estudiantes WHERE " +
                        "LOWER(nombres) LIKE LOWER(CONCAT('%', @busqueda, '%')) OR " +
                        "LOWER(apellidos) LIKE LOWER(CONCAT('%', @busqueda, '%'))";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@busqueda", busqueda);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add(Convert.ToInt32(reader["id_estudiante"]));
                        }

                        return ids;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                connection.CloseConnection();
            }
        }
        public List<Clases.ClassGetEstudiantes> ObtenerEstudiantes()
        {
            DB_Connection connection = new DB_Connection();

            List<Clases.ClassGetEstudiantes> estudiantes = new List<Clases.ClassGetEstudiantes>();

            try
            {
                using (MySqlConnection con = connection.GetConnection())
                {
                    string query = "SELECT * FROM estudiantes LIMIT 10";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
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

                            if(poseeDatos == true)
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
            } catch (Exception)
            {
                Console.WriteLine("Error al obtener los estudiantes");
            } finally
            {
                connection.CloseConnection();
            }

            return estudiantes;
        }
        public int ObtenerIdPorCodigo(string codigo)
        {
            DB_Connection connection = new DB_Connection();

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    string query = "SELECT id_estudiante FROM datos_academicos WHERE codigo_estudiante = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return Convert.ToInt32(reader["id_estudiante"]);
                    }
                }
            } catch (Exception)
            {
                return -1;
            } finally
            {
                connection.CloseConnection();
            }
        }
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

                        if(!reader.HasRows)
                        {
                            return "Estudiante no encontrado";
                        }

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
                    string territorioIndigena = (estudiante.TerritorioIndigena != "") ? estudiante.TerritorioIndigena : "Ninguna";
                    string comunidadIndigena = (estudiante.ComunidadIndigena != "") ? estudiante.ComunidadIndigena : "Ninguna";

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
                        long idEstudiante = cmd.LastInsertedId;
                        return "El código temporal del estudiante es: " + idEstudiante;
                    }
                    else
                    {
                        return "No se agregó el estudiante";
                    }
                }
            } catch (Exception ex)
            {
                return "No se agregó el estudiante";
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
