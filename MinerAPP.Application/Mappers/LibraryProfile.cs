﻿using AutoMapper;
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
                .ReverseMap();
        }
    }
}