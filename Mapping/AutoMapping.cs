using AutoMapper;
using BlogSystemAPI.Dtos;
using BlogSystemAPI.Models;

namespace BlogSystemAPI.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateBlogDto, Blog>();
        }
    }
}