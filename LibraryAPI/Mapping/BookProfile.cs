using AutoMapper;
using LibraryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookEntity, Book>();
            CreateMap<StatusHistoryEntity, BookStatus>();
            CreateMap<InsertBookDto, BookEntity>();
        }
    }
}
