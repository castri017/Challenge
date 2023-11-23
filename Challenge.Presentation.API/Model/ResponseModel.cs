using Newtonsoft.Json;

namespace Challenge.Presentation.API.Model
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public object Response { get; set; }
        public object meta { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}