using AutoMapper;

namespace maple_web_api_async.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Entities.Book, Models.Book>().
            ForMember(dest => dest.Author,
             opt => opt.MapFrom(src => $"{src.Author.LastName}, {src.Author.FirstName}"));

            CreateMap<Models.BookForCreation, Entities.Book>();
        }
    }
}