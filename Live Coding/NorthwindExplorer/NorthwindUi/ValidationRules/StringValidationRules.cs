using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NorthwindUi.ValidationRules
{
    public class StringNotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value?.ToString();

            if (String.IsNullOrWhiteSpace(text))
            {
                return new ValidationResult(false, "Dieser String muss gefüllt sein.");

            }
            return new ValidationResult(true, "");
        }
    }

    public class StringLengthValidationRule : ValidationRule
    {
        public int Length { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value?.ToString();

            if (String.IsNullOrWhiteSpace(text) || text.Length != this.Length)
            {
                return new ValidationResult(false, $"Dieser String muss {Length} Zeichen lang sein.");

            }
            return new ValidationResult(true, "");

        }
    }
}
