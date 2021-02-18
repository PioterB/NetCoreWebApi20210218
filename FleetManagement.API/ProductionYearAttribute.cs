using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.API
{
    [AttributeUsage(AttributeTargets.Property
                    | AttributeTargets.Field
                    | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class ProductionYearAttribute : ValidationAttribute
    {
        private string error = "";

        public bool AllowShortNotation { get; set; }

        public int MinimumSupportedYear { get; set; } = 1950;
        
        public override string FormatErrorMessage(string name)
        {
            return "error";
        }

        
        public override bool IsValid(object value)
        {
            if (value == null || value is string == false )
            {
                return false;
            }

            var text = value.ToString();
            if (text.Length != 4 && text.Length != 2)
            {
                return false;
            }

            if (int.TryParse(text, out var year) == false)
            {
                return false;
            }

            if (year < 100)
            {
                year += year + 2000 > DateTime.Now.Year ? 1900 : 2000;
            }

            return year >= MinimumSupportedYear && year < DateTime.Now.Year;
        }
    }
}