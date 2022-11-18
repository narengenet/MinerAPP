using AutoMapper;
using MinerAPP.Application.DTO;
using MinerAPP.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerAPP.Application.Mappers
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            /*
                This is where we are mapping from 
                entity to view model and vice versa.
            */
            CreateMap<Users, User>()
                .ForMember(dest => dest.surename, opt => opt.MapFrom(src => src.Family))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.FullName()))
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.phone, opt => opt.MapFrom(src => src.Cellphone))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.devicemodel, opt => opt.Ignore())
                .ForMember(dest => dest.imei, opt => opt.Ignore())
                .ReverseMap();
            
            CreateMap<Transactions, Transaction>()
                .ForMember(dest => dest.amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.confirmed, opt => opt.MapFrom(src => src.Confirmed))
                .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.hash, opt => opt.MapFrom(src => src.TheHash))
                .ForMember(dest => dest.isdeposit, opt => opt.MapFrom(src => src.IsDeposit))
                .ReverseMap();
        }
    }
}
