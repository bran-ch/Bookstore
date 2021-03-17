using AutoMapper;
using BookstoreApi.Entities;
using BookstoreApi.Models;

namespace BookstoreApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book Model to Entity
            CreateMap<BookModel, BookEntity>()
                .ForMember(e => e.Title, m => m.MapFrom(b => b.Title))
                .ForMember(e => e.Author, m => m.MapFrom(b => b))
                .ForMember(e => e.BookDetail, m => m.MapFrom(b => b))
            ;

            CreateMap<BookModel, AuthorEntity>()
                .ForMember(e => e.Name, m => m.MapFrom(b => b.Author))
            ;

            CreateMap<BookModel, BookDetailEntity>()
                .ForMember(e => e.BookId, m => m.MapFrom(b => b.BookId))
                .ForMember(e => e.Description, m => m.MapFrom(b => b.Description))
                .ForMember(e => e.ImagePath, m => m.MapFrom(b => b.ImagePath))
                .ForMember(e => e.Price, m => m.MapFrom(b => b.Price))
            ;

            // Book Entity to Model
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
