using LibraryAPI.Extensions;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibraryAPI.Providers
{
    public class BookProvider : IBookProvider
    {
        private readonly IHttpClientFactory clientFactory;

        public BookProvider(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<BookPrice> GetPriceById(Guid bookId)
        {
            var client = clientFactory.CreateClient();

            var response = await client.GetAsync($"http://60c35511917002001739e94a.mockapi.io/api/v1/Prices/{bookId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot fetching Book Price");
            }

            return await response.DeserializeObject<BookPrice>();
        }
    }
}
