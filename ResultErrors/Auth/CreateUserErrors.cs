using Catansy.API.Models.Responses.Common;

namespace Catansy.API.ResultErrors.Auth;

public static class CreateUserErrors
{
    public static readonly Error MailAlreadyExits = 
        new("Mail.Exists", "Mail already exists", StatusCodes.Status400BadRequest);
}