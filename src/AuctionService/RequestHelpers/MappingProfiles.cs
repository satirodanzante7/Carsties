using AuctionService;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;


namespace SearchService;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(dest => dest.Item, o => o.MapFrom(src => src));
        CreateMap<CreateAuctionDto, Item>();
    }
}

