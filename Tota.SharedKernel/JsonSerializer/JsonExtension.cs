using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tota.SharedKernel.JsonSerializer
{
    public static class JsonExtension
    {
        public static string ToJson(this object data, bool formatting = false)
        {
            if (data == default)
                return default;

            return SystemTextJsonSerializer.Serialize(data, formatting);
        }

        public static T ToObject<T>(this string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return default;

            return SystemTextJsonSerializer.Deserialize<T>(data);
        }
    }
}
