using System.ComponentModel.DataAnnotations;

namespace Proyecto.CustomAttributes
{
    // Clase que contiene el atributo de validacion [Required] personalizado. 
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return $"* {name} must not be Empty";
        }
    }
}
