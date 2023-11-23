namespace Challenge.Common.Utils.Contracts
{
    public interface ISerializeJson
    {
        T DeserializeEntity<T>(byte[] data);
        IEnumerable<T> DeserializeToList<T>(byte[] data);
        byte[] SerializeToByte<T>(T data);
        string SerializeToJson<T>(T entity);
        string SerializeToJson<T>(T entity, Type type);
        T DeserializeEntity<T>(string json, Type type);
        T DeserializeEntity<T>(string json);
    }
}
