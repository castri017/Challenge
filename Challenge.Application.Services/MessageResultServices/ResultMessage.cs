namespace Challenge.Application.Services.MessageResultServices
{
    public class ResultMessage : IResultMessage
    {
        public Dictionary<string, Dictionary<string, string>>? Message { get; set; }
    }
}
