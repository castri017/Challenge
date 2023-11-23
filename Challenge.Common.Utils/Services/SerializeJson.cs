using Challenge.Common.Utils.Contracts;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Challenge.Common.Utils.Services
{
    public class SerializeJson : ISerializeJson
    {
        /// <summary>
        /// convert array bytes in entity T
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="data">array bytes</param>
        /// <returns>entity type T</returns>
        public T DeserializeEntity<T>(byte[] data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
        /// <summary>
        ///  convert array bytes in IEnumerable<T>
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="data">array bytes</param>
        /// <returns>IEnumerable<T></T></returns>
        public IEnumerable<T> DeserializeToList<T>(byte[] data)
        {
            return JsonSerializer.Deserialize<IEnumerable<T>>(data);
        }
        /// <summary>
        /// convert entity type T in array bytes
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="data">entity bytes</param>
        /// <returns>array in bytes</returns>
        public byte[] SerializeToByte<T>(T data)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data);
        }

        public string SerializeToJson<T>(T entity)
        {
            return JsonSerializer.Serialize(entity);
        }
        public string SerializeToJson<T>(T entity, Type type)
        {
            return JsonSerializer.Serialize(entity, type);
        }


        public T DeserializeEntity<T>(string json, Type type)
        {
            return (T)JsonSerializer.Deserialize(json, type, getOptionJson());
        }
        public T DeserializeEntity<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, getOptionJson());
        }
        private JsonSerializerOptions getOptionJson()
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            options.PropertyNameCaseInsensitive = true;
            return options;
        }
    }
}
