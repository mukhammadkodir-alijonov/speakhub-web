using System.ComponentModel.DataAnnotations;

namespace SpeakHub.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TweetCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return new ValidationResult("You can create a new tweet!");
            else
            {
                var size = int.Parse(value.ToString()!);
                if (size >= 180) return new ValidationResult("The value should not be greater than 180");
                if (size <= 5) return new ValidationResult("The value must not be less than 5");
                return ValidationResult.Success;
            }
        }
    }
}
