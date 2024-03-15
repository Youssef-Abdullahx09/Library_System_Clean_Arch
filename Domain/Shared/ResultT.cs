namespace Domain.Shared;

public class Result<TValue> : Result
{
    private readonly TValue? _value;
    private Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error) =>
        _value = value;

    public TValue? Value => IsSuccess
        ? _value : throw new InvalidOperationException("The value of a failure result can not be accessed.");
    public static Result<TValue> Success(TValue value) => new Result<TValue>(value, true, Error.None);

    public static implicit operator Result<TValue>(TValue? value) => Success(value);
    public static implicit operator Result<TValue>(Error error) => new Result<TValue>(default, false, error);
}
