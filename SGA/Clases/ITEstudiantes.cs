using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Clases
{
    public interface ITEstudiantes
    {
        // Datos personales de los estudiantes
        int Id { get; set; }
        string Nombres { get; set; }
        string Cedula { get; set; }
        string FechaNacimiento { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        bool PartidaNacimiento { get; set; } 
        string FechaMatricula { get; set; }
        string Barrio { get; set; }
        double Peso { get; set; }
        double Talla { get; set; }
        string TerritorioIndigena { get; set; }
        string ComunidadIndigena { get; set; }
        string Sexo { get; set; }
        string Pais { get; set; }
        string Departamento { get; set; }
        string Municipio { get; set; }
        string Nacionalidad { get; set; }
        string Etnia { get; set; }
        string LenguaMaterna { get; set; }
        string Discapacidad { get; set; }

        // Datos de los padres de los estudiantes

        string NombresTutor { get; set; }
        string CedulaTutor { get; set; }
        string TelefonoTutor { get; set; }

        // Datos académicos de los estudiantes

        string CodigoEstudiante { get; set; }
        string FechaMatriculaAcademica { get; set; }
        string NivelEducativo { get; set; }
        bool Repitente { get; set; }
        string Modalidad { get; set; }
        string Grado { get; set; }
        string Seccion { get; set; }
        string Turno { get; set; }
        string CentroEducativo { get; set; }




    }
}
