using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace MinimalApi.Domain.Common;

public class UserName : ValueOf<string, UserName>
{
    private static readonly Regex FullNameRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        if (!FullNameRegex.IsMatch(Value))
        {
            var message = $"{Value} is not a valid username";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(UserName), message)
            });
        }
    }
}