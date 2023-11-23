namespace Challenge.Application.Services.MessageResultServices
{
    public interface IResultMessage
    {
        Dictionary<string, Dictionary<string, string>> Message { get; set; }
    }
}
