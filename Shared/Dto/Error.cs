namespace Shared.Dto;

public record Error
{
    public Error(string message, int? codeError = null)
    {
        Message = message;
        CodeError = codeError;
    }

    public string Message { get; }
    public int? CodeError { get; }
}