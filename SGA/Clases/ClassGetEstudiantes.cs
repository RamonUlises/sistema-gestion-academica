using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Clases
{
    public class ClassGetEstudiantes:Clases.ITEstudiantes
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool PartidaNacimiento { get; set; }
        public string FechaMatricula { get; set; }
        public string Barrio { get; set; }
        public double Peso { get; set; }
        public double Talla { get; set; }
        public string TerritorioIndigena { get; set; }
        public string ComunidadIndigena { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Nacionalidad { get; set; }
        public string Etnia { get; set; }
        public string LenguaMaterna { get; set; }
        public string Discapacidad { get; set; }
        public string NombresTutor { get; set; }
        public string CedulaTutor { get; set; }
        public string TelefonoTutor { get; set; }
        public string CodigoEstudiante { get; set; }
        public string FechaMatriculaAcademica { get; set; }
        public string NivelEducativo { get; set; }
        public bool Repitente { get; set; }
        public string Modalidad { get; set; }  
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public string Turno { get; set; }
        public string CentroEducativo { get; set; }

    }
}
