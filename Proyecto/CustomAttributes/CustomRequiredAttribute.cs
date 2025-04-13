using System.ComponentModel.DataAnnotations;

namespace Proyecto.CustomAttributes
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return $"* {name} must not be Empty";
        }
    }
}
