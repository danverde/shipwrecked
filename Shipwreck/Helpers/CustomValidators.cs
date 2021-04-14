using System;
using Sharprompt.Validations;

namespace Shipwreck.Helpers
{
    public class CustomValidators
    {
        public static Func<object, ValidationResult> IsLessThan(double max) => 
            input =>
            {
                if (!double.TryParse(input.ToString(), out var numericInput))
                    return (ValidationResult) null;
                return numericInput < max ? (ValidationResult) null : new ValidationResult($"Value larger than {max - 1}");
            };
        
        public static Func<object, ValidationResult> IsLessOrEqualTo(double max) => 
            input =>
            {
                if (!double.TryParse(input.ToString(), out var numericInput))
                    return (ValidationResult) null;
                return numericInput <= max ? (ValidationResult) null : new ValidationResult($"Value larger than {max}");
            };
        
        public static Func<object, ValidationResult> IsGreaterThan(double min) => 
            input =>
            {
                if (!double.TryParse(input.ToString(), out var numericInput))
                    return (ValidationResult) null;
                return numericInput > min ? (ValidationResult) null : new ValidationResult($"Value smaller than {min + 1}");
            };
        
        public static Func<object, ValidationResult> IsGreaterOrEqualTo(double min) => 
            input =>
            {
                if (!double.TryParse(input.ToString(), out var numericInput))
                    return (ValidationResult) null;
                return numericInput > min ? (ValidationResult) null : new ValidationResult($"Value smaller than {min}");
            };
    }
}