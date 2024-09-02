namespace Catansy.API.Models.Responses.Common;

public sealed record Error(
    string Code,
    string? Message = null,
    int _statusCode = StatusCodes.Status500InternalServerError)
{
    private readonly int _statusCode = _statusCode;

    public int StatusCode() => _statusCode;
}