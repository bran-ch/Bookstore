using AutoMapper;
using BookstoreApi.Entities;
using BookstoreApi.Models;

namespace BookstoreApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookModel, BookEntity>();

            CreateMap<BookEntity, BookModel>()
                .ForMember(b => b.BookId, m => m.MapFrom(e => e.BookId))
                .ForMember(b => b.Author, m => m.MapFrom(e => e.Author.Name))
                .ForMember(b => b.Title, m => m.MapFrom(e => e.Title))
                .ForMember(b => b.Description, m => m.MapFrom(e => e.BookDetail.Description))
                .ForMember(b => b.ImagePath, m => m.MapFrom(e => e.BookDetail.ImagePath))
                .ForMember(b => b.Price, m => m.MapFrom(e => e.BookDetail.Price))
            ;
        }
    }
}
