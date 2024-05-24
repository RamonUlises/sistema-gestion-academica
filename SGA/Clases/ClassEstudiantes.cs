using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGA.Clases
{
    public class ClassEstudiantes
    {
        public int Id { get; set; }
        public string Nombre1 { get; set; } // ya
        public string Nombre2 { get; set; } // ya
        public string Apellido1 { get; set; } // ya
        public string Apellido2 { get; set; } // ya
        public string Cedula { get; set; } // ya
        public bool PartidaNacimiento { get; set; } // ya
        public string FechaNacimiento { get; set; } // ya
        public string Telefono { get; set; } // ya
        public string Direccion { get; set; } // ya
        public string FechaMatricula { get; set; } // ya
        public string Barrio { get; set; } // ya
        public double Peso { get; set; } // ya
        public double Talla { get; set; } // ya
        public string TerritorioIndigena { get; set; } // ya
        public string ComunidadIndigena { get; set; } // ya
        public string Sexo { get; set; } // ya
        public string Pais { get; set; } // ya
        public string Departamento { get; set; } // ya
        public string Municipio { get; set; } // ya
        public string Nacionalidad { get; set; } // ya
        public string Etnia { get; set; } // ya
        public string Lengua { get; set; } // ya
        public string Discapacidad { get; set; } // ya
        public string NombresTutor { get; set; } // ya
        public string CedulaTutor { get; set; } // ya
        public string TelefonoTutor { get; set; } // ya
      
        // Validación de nombres
        public ValidarResultados ValidarNombres()
        {

            if (this.Nombre1.Length == 0 || this.Nombre2.Length == 0) {
                return Validation(false, "Los nombres son requeridos");
            }

            string pattern = @"^(?:[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+(?:\s|$)){1,5}$";

            if (Regex.IsMatch(this.Nombre1, pattern) && Regex.IsMatch(this.Nombre2, pattern))
            {
                return Validation(true, "Correcto");
            }
            return Validation(false, "Los nombres son inválidos");
        }
        // Validación de apellidos
        public ValidarResultados ValidarApellidos()
        {

            if (this.Apellido1.Length == 0 || this.Apellido2.Length == 0)
            {
                return Validation(false, "Los apellidos son requeridos");
            }

            string pattern = @"^[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+$";
            if (Regex.IsMatch(this.Apellido1, pattern) == true && Regex.IsMatch(this.Apellido2, pattern) == true)
            {
                return Validation(true, "Correcto");
            }
            return Validation(false, "Los apellidos son inválidos");
        }
        // Validación de cédula
        public ValidarResultados ValidarCedula()
        {
            if(this.Cedula.Length == 0) return new ValidarResultados { result = true, message = "GG" };
            string pattern = "^[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]{1}$";
            
            if(!Regex.IsMatch(this.Cedula, pattern))
            {
                return Validation(false, "El formato de la cédula debe ser 000-000000-0000X");
            }
                return Validation(true, "GG");
        }
        // Validación de teléfono
        public ValidarResultados ValidarTelefono()
        {
            if(this.Telefono.Length == 0) return Validation(true, "gg");
            string pattern = @"^[0-9]{4}-[0-9]{4}$";
            
            if(!Regex.IsMatch(this.Telefono, pattern))
            {
                return Validation(false, "El formato del teléfono debe ser 0000-0000");
            }
            return Validation(true, "gg");
        }
        public ValidarResultados ValidarEspacios()
        {
            if(this.Pais.Length == 0)
            {
                return Validation(false, "El pais es requerido");
            }

            if (this.Departamento.Length == 0)
            {
                return Validation(false, "El departamento es requerido");
            }

            if (this.Municipio.Length == 0)
            {
                return Validation(false, "El municipio es requerido");
            }
            
            if (this.Barrio.Length == 0)
            {
               return Validation(false, "El barrio es requerido");
            } 

            if (this.Direccion.Length == 0)
            {
                return Validation(false, "La dirección es requerida");
            }
            
            if (this.Etnia.Length == 0)
            {
                return Validation(false, "La etnia es requerida");
            }
            
            if (this.Lengua.Length == 0)
            {
                return Validation(false, "La lengua es requerida");
            }

            if (this.NombresTutor.Length == 0)
            {
                return Validation(false, "El nombre del tutor es requerido");
            }
            
            if (this.CedulaTutor.Length == 0)
            {
                return Validation(false, "La cédula del tutor es requerida");
            }
            
            if (this.TelefonoTutor.Length == 0)
            {
                return Validation(false, "El teléfono del tutor es requerido");
            }

            return Validation(true, "GG");
        }

        public ValidarResultados ValidarPesoTalla()
        {
            if(this.Peso == 0)
            {
                return Validation(false, "El peso es requerido");
            }
            if(this.Talla == 0) {
                return Validation(false, "La talla es requerida");
            } 
            return Validation(true, "GG");
        }

        public ValidarResultados ValidarFechaNacimiento()
        {
            string pattern = @"^[0-9]{2}-[0-9]{2}-[0-9]{4}$";
            
            if(!Regex.IsMatch(this.FechaNacimiento, pattern))
            {
                return Validation(false, "El formato de la fecha de nacimiento es dd-mm-yyyy");
            }
            return Validation(true, "GG");
        }

        public ValidarResultados ValidarNombresTutor()
        {
            string pattern = @"^(?:[A-ZÁÉÍÓÚÑ][a-záéíóúñ]+(?:\s|$)){1,5}$";
            
            if(!Regex.IsMatch(this.NombresTutor, pattern))
            {
                return Validation(false, "El nombre del tutor es inválido");
            }

            return Validation(true, "GG");
        }

        public ValidarResultados ValidarCedulaTutor()
        {
            string pattern = @"^[0-9]{3}-[0-9]{6}-[0-9]{4}[A-Z]{1}$";
            
            if(!Regex.IsMatch(this.CedulaTutor, pattern))
            {
                return Validation(false, "La cédula del tutor es inválida");
            }
            return Validation(true, "GG");
        }
        public ValidarResultados Validation(bool result, string message)
        {
            return new ValidarResultados { result = result, message = message };
        }

    }
}

// var result = ValidateSomething(); // Llamada al método
// if (result.IsSuccessful)
//{
//    Console.WriteLine($"Éxito: {result.Message}");
//}
//else
//{
//    Console.WriteLine($"Error: {result.Message}");
//}
