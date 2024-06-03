using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGA.Clases
{
    internal class ClassTraslado
    {
       public string CodigoEstudiante;
       public string MotivoTraslado;
       public string FechaTraslado;
        public string CentroOrigen;
        public string PeriodoTraslado;

        public ValidarResultados ValidarCampos(){
            if(CodigoEstudiante.Length == 0){
                return Validation(false, "El campo codigo estudiante no puede estar vacio");
            }
            if(MotivoTraslado.Length == 0){
                return Validation(false, "El campo motivo del traslado no puede estar vacio");
            }
            if(FechaTraslado.Length == 0){
                return Validation(false, "El campo fecha traslado no puede estar vacio");
            }
            if(CentroOrigen.Length == 0){
                return Validation(false, "El campo centro origen no puede estar vacio");
            }
            if(PeriodoTraslado.Length == 0){
                return Validation(false, "El campo periodo Traslado no puede estar vacio");
            }

            return Validation(true, "Campos validados correctamente");
        }

        public ValidarResultados ValidarFecha()
        {
            string pattern = @"^[0-9]{2}-[0-9]{2}-[0-9]{4}$";

            if (!Regex.IsMatch(this.FechaTraslado, pattern))
            {
                return Validation(false, "El formato de la fecha de nacimiento es dd-mm-yyyy");
            }
            return Validation(true, "GG");
        }

        public ValidarResultados Validation(bool result, string message){
            return new ValidarResultados { result = result, message = message };
        }
    }
}
