namespace Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if ((isSuccess && error != Error.None)
            || (!isSuccess && error == Error.None))
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }
    public bool IsSuccess { get; }
    public Error Error { get; }

    public bool IsFailure => !IsSuccess;
    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);
    public static implicit operator Result(Error error) => Failure(error);
}
