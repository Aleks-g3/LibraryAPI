using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryAPI.Extensions
{
    public static class HttpExtentions
    {
        public static async Task<T> DeserializeObject<T>(this HttpResponseMessage responseMessage)
        {
            var stringContent = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
}
