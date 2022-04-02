namespace Shared.Dto;

public record Result<T>
{
    public Result(T resultOperation)
    {
        ResultOperation = resultOperation;
    }

    public Result(Error error)
    {
        Error = error;
    }

    public T ResultOperation { get; }
    public Error Error { get; }
}