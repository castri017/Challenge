using System.Text.Json;

namespace Challenge.Common.Exceptions.Helpers
{
    public class ResponseError
    {
        public int StatusCode { get; set; }
        public object Response { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}