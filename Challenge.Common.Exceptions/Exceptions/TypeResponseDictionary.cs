namespace Challenge.Common.Exceptions.Exceptions
{
    public class TypeResponseDictionary
    {
        public Dictionary<int, string> TypeResponse { get; set; }
        public TypeResponseDictionary()
        {
            TypeResponse = new Dictionary<int, string>
            {
                { 202, "Se acepto la solicitud pero no se obtuvo respuesta." },
                { 204, "No se encontro contendido. La solicitud no contiene información." },
                { 400, "La solicitud no ha sido entendida por el sistema, por favor verifica la información." },
                { 401, "El recurso solicitado requiere autenticación en el sistema." },
                { 403, "La solicitud no ha podido ser procesada. Por favor comunìquese con el administrador." },
                { 404, "No hemos podido encontrar tu solicitud, el recurso ha sido eliminado o no existe." },
                { 405, "La solicitud ha sido deshabilitada temporalmente." },
                { 500, "Ha ocurrido un error inesperado, La solicitud no ha podido ser procesada." }
            };
        }
    }

}
