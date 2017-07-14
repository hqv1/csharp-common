using FluentValidation;
using Hqv.CSharp.Common.Exceptions;

namespace Hqv.CSharp.Common.Validations
{
    public static class Validator
    {
        public static void Validate<TT, TValidator>(TT obj)
            where TValidator : AbstractValidator<TT>, new()
        {
            var validator = new TValidator();
            var validationResult = validator.Validate(obj);
            if (validationResult.IsValid) return;

            var exception = new HqvException("Validation failed");
            exception.Data["errors"] = validationResult.Errors;
            throw exception;
        }

        public static void Validate<TT, TValidator>(TT obj, TValidator validator)
            where TValidator : AbstractValidator<TT>, new()
        {            
            var validationResult = validator.Validate(obj);
            if (validationResult.IsValid) return;

            var exception = new HqvException("Validation failed");
            exception.Data["errors"] = validationResult.Errors;
            throw exception;
        }
    }
}
