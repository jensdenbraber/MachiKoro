using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MachiKoro.Domain.UnitTests;

public abstract class BaseUnitTest
{
    public List<ValidationResult> Validate(object sut)
    {
        var ctx = new ValidationContext(sut, null, null);
        var errors = new List<ValidationResult>();
        Validator.TryValidateObject(sut, ctx, errors, true);
        return errors;
    }
}