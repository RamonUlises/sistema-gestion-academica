using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGA.Clases
{
    internal class ClassTraslado
    {
       public string CodigoEstudiante;
       public string NombresEstudiante;
       public string FechaTraslado;
        public string CentroOrigen;
        public string PeriodoTraslado;

        public ValidarResultados ValidarCampos(){
            if(CodigoEstudiante.Length == 0){
                return Validation(false, "El campo Codigo Estudiante no puede estar vacio");
            }
            if(NombresEstudiante.Length == 0){
                return Validation(false, "El campo Nombres Estudiante no puede estar vacio");
            }
            if(FechaTraslado.Length == 0){
                return Validation(false, "El campo Fecha Traslado no puede estar vacio");
            }
            if(CentroOrigen.Length == 0){
                return Validation(false, "El campo Centro Origen no puede estar vacio");
            }
            if(PeriodoTraslado.Length == 0){
                return Validation(false, "El campo Periodo Traslado no puede estar vacio");
            }

            return Validation(true, "Campos validados correctamente");
        }

        public ValidarResultados Validation(bool result, string message){
            return new ValidarResultados { result = result, message = message };
        }
    }
}
