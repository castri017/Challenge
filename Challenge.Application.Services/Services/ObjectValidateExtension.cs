namespace Challenge.Application.Services.Services
{
    public static class ObjectValidateExtension
    {

        #region List
        public static bool hasRecords<T>(this List<T> value)
        {
            return value != null && value.Count > 0;
        }
        public static bool hasNoRecords<T>(this List<T> value)
        {
            return value == null || value?.Count == 0;
        }

        #endregion

        #region Entity
        public static bool hasRecords<T>(this T value)
        {
            return value != null;
        }
        public static bool hasNoRecords<T>(this T value)
        {
            return value == null;
        }

        #endregion
    }
}
