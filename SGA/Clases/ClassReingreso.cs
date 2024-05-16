using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Clases
{
    internal class ClassReingreso
    {
        public string CodigoAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string CodigoUnico { get; set; }
        public string CodigoCentro { get; set; }
        public string Centro { get; set; }
        public string Modalidad { get; set; }
        public string Turno { get; set; }
        public string Grado { get; set; }
        public string Seccion { get; set; }

        public ValidarResultados ValidarEspacios()
        {
            if(this.CodigoAlumno.Length == 0)
            {
                return Validation(false, "El código del alumno es requerido");
            }

            if(this.NombreAlumno.Length == 0)
            {
                return Validation(false, "El nombre del alumno es requerido");
            }

            if(this.CodigoUnico.Length == 0)
            {
                return Validation(false, "El código único es requerido");
            }

            if(this.CodigoCentro.Length == 0)
            {
                return Validation(false, "El código del centro es requerido");
            }

            if(this.Centro.Length == 0)
            {
                return Validation(false, "El nombre del centro es requerido");
            }

            if(this.Modalidad.Length == 0)
            {
                return Validation(false, "La modalidad es requerida");
            }

            if(this.Turno.Length == 0)
            {
                return Validation(false, "El turno es requerido");
            }

            if(this.Grado.Length == 0)
            {
                return Validation(false, "El grado es requerido");
            }

            if(this.Seccion.Length == 0)
            {
                return Validation(false, "La sección es requerida");
            }

            return Validation(true, "GG");
        }
        public ValidarResultados Validation(bool result, string message)
        {
            return new ValidarResultados { result = result, message = message };
        }
    }
}
