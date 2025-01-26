using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicenseManagement.Golbal_Classes
{
    public class clsFormat
    {
        private string FormatValue<T>(T? Value) where T : struct
        {
            if (Value is DateTime date)
                return date.ToString("dd/MMM/yyyy", CultureInfo.CreateSpecificCulture("en-US"));
            else if (Value is decimal decimalValue)
                return decimalValue.ToString("#.##");
            return Value?.ToString() ?? "[???]";
        }

        private string FormatFees(decimal? value) => value?.ToString("#.##") ?? "[$$$]";

        private string FormatValue(string Value) => !string.IsNullOrEmpty(Value) ? Value : "[???]";

    }
}
