using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Providers
{
    public interface IBookProvider
    {
        Task<BookPrice> GetPriceById(Guid bookId);
    }
}
