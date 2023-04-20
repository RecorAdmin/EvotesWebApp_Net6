using AutoMapper;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Configeration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Candidates, CandidateVM>().ReverseMap();
        }
    }
}
