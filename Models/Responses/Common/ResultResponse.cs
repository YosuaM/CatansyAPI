namespace Catansy.API.Models.Responses.Common;

public record ResultResponse<TValue, TError>
{
    public readonly TValue? Value;
    public readonly TError? Error;

    public bool IsSuccess { get; }

    private ResultResponse(TValue value)
    {
        IsSuccess = true;
        Value = value;
        Error = default;
    }

    private ResultResponse(TError error)
    {
        IsSuccess = false;
        Value = default;
        Error = error;
    }

    //happy path
    public static implicit operator ResultResponse<TValue, TError>(TValue value) => new ResultResponse<TValue, TError>(value);

    //error path
    public static implicit operator ResultResponse<TValue, TError> (TError error) => new ResultResponse<TValue, TError>(error);

    public ResultResponse<TValue, TError> Match(Func<TValue, ResultResponse<TValue, TError>> success, Func<TError, ResultResponse<TValue, TError>> failure)
    {
        return IsSuccess ? success(Value!) : failure(Error!);
    }
}