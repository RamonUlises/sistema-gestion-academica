using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Clases
{
    public class ClassDatosAcademicos
    {
        public string FechaMatricula { get; set; }
        public string CodigoEstudiante { get; set; }
        public string NombreCentroEducativo { get; set; }
        public string NivelEducativo { get; set; }
        public string Modalidad { get; set; }
        public string Turno { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }
        public bool Repitente { get; set; }

        // Validación de campos vacíos

        public ValidarResultados ValidarCamposVacios()
        {
            if(this.CodigoEstudiante.Length == 0)
            {
                return Validation(false, "El código del estudiante es requerido");
            }

            if (this.NombreCentroEducativo.Length == 0)
            {
                return Validation(false, "El nombre del centro educativo es requerido");
            }

            if (this.NivelEducativo.Length == 0)
            {
                return Validation(false, "El nivel educativo es requerido");
            }

            if (this.Modalidad.Length == 0)
            {
                return Validation(false, "La modalidad es requerida");
            }

            if (this.Turno.Length == 0)
            {
                return Validation(false, "El turno es requerido");
            }

            if (this.Grado.Length == 0)
            {
                return Validation(false, "El grado es requerido");
            }

            if (this.Seccion.Length == 0)
            {
                return Validation(false, "La sección es requerida");
            }

            return Validation(true, "Correcto");
        }

        public ValidarResultados Validation(bool result, string message)
        {
            return new ValidarResultados { result = result, message = message };
        }
    }
}
