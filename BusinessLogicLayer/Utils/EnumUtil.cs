namespace BusinessLogicLayer.Utils
{
    public class EnumUtil
    {
        public static T GetEnumFromString<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, out T @enum))
            {
                return @enum;
            }

            throw new InvalidDataException($"Invalid enum value of type {typeof(T)}");
        }

        public static List<string> GetValuesAsListString<T>()
        {
            return [.. Enum.GetValues(typeof(T)).Cast<T>().Select(e => e?.ToString())];
        }
    }
}
