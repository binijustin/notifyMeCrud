using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace NotifyMeCRUD.Validation.CustomValidator;

public static class DateTimeValidator
{
    public static IRuleBuilderOptions<T, DateTime> AfterSunrise<T>(this IRuleBuilder<T, DateTime> ruleBuilder)
    {
        // //Normal Version
        // var sunrise = TimeOnly.MinValue.AddHours(6);
        // return ruleBuilder.Must(dateTime => TimeOnly.FromDateTime(dateTime) > sunrise);
        
        //Using Property
        var sunrise = TimeOnly.MinValue.AddHours(6);

        return ruleBuilder.Must((objectRoot, dateTime,context) => {
            TimeOnly providedTime = TimeOnly.FromDateTime(dateTime);
            
            context.MessageFormatter.AppendArgument("Sunrise",sunrise);
            context.MessageFormatter.AppendArgument("ProvidedTime", providedTime);

            return providedTime > sunrise;
        })
        .WithMessage("{PropertyName} must be after {Sunrise}. You provided {ProvidedTime}.");


    }
}