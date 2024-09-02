using Catansy.API.Models.Responses.Common;

namespace Catansy.API.ResultErrors.Auth;

public static class LoginErrors
{
    public static readonly Error UserIncorrectPasswordOrNotFound = 
        new("User.IncorrectPasswordOrUserNotFound", "Incorrect password or user not found", StatusCodes.Status404NotFound);
    
    public static readonly Error UserIsBanned = 
        new("User.Banned", "The user is banned", StatusCodes.Status400BadRequest);
}