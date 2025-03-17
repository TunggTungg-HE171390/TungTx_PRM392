using AutoMapper;
using Slot3_CodeFirst.Db.Models;
using Slot3_CodeFirst.DTO.Player;
using Slot3_CodeFirst.DTO.PlayerInstrument;

namespace Slot3_CodeFirst
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Player, CreatePlayerRequest>().ReverseMap();
            CreateMap<Player, UpdatePlayerRequest>().ReverseMap();
            CreateMap<Player, GetPlayerDetailResponse>().ReverseMap();
            CreateMap<Player, GetPlayerResponse>()
                .ForMember(dest => dest.InstrumentSummitedCount, opt => opt.MapFrom(src => src.Instruments.Count))
                .ReverseMap();

            CreateMap<PlayerInstrument, GetPlayerInstrumentResponse>().ReverseMap();
            CreateMap<PlayerInstrument, CreatePlayerInstrumentRequest>().ReverseMap();
            
        }
    }
}
