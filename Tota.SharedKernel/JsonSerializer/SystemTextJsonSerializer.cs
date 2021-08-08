using System.Text.Json.Serialization;
using STJ = System.Text.Json;

namespace Tota.SharedKernel.JsonSerializer
{
    public static class SystemTextJsonSerializer
    {
        public static string Serialize(object data, bool formatting = false)
        {
            var options = GetOptionsToSerialize(formatting);
            return STJ.JsonSerializer.Serialize(data, options);
        }

        public static T Deserialize<T>(string data)
        {
            var options = GetOptionsToDeserialize();
            return STJ.JsonSerializer.Deserialize<T>(data, options);
        }

        //Public due sometimes is used by other libraries like Refit Restclient.
        public static STJ.JsonSerializerOptions GetOptionsToSerialize(bool formatting)
        {
            return new STJ.JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                PropertyNamingPolicy = STJ.JsonNamingPolicy.CamelCase,
                WriteIndented = formatting,
                Converters =
                {
                    new JsonStringEnumConverter(STJ.JsonNamingPolicy.CamelCase),
                    new DateTimeConverter()
                }
            };
        }

        private static STJ.JsonSerializerOptions GetOptionsToDeserialize()
        {
            return new STJ.JsonSerializerOptions(STJ.JsonSerializerDefaults.Web)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                                       | JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                    new JsonStringEnumConverter(STJ.JsonNamingPolicy.CamelCase),
                    new DateTimeConverter()
                }
            };
        }
    }
}
