using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CommentAttribute : ValidationAttribute
    {
        private readonly int _maxLength;
        private readonly int _minLength;

        public CommentAttribute(int maxLength = 180, int minLength = 2)
        {
            _maxLength = maxLength;
            _minLength = minLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // Optional field; no validation needed if it's null.
                return ValidationResult.Success;
            }

            if (value is not string tweet)
            {
                // Value should be a string.
                return new ValidationResult("The value must be a string.");
            }

            if (tweet.Length > _maxLength)
            {
                return new ValidationResult($"The tweet length should not exceed {_maxLength} characters.");
            }

            if (tweet.Length < _minLength)
            {
                return new ValidationResult($"The tweet length must be at least {_minLength} characters.");
            }

            return ValidationResult.Success;
        }
    }
}
