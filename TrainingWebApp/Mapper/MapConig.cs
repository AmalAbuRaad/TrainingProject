using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingWebApp.Models;
using TrainingWebApp.ViewModels;

namespace TrainingWebApp.Mapper
{
    public class MapConig : Profile
    {
        public MapConig()
        {
            /*CreateMap<User, UserViewModel>()
                            .ForMember(d => d.Name, d => d.MapFrom(s => string.Format("{0} {1}", s.FirstName, s.LastName)))
                            .ReverseMap();*/
            CreateMap<User, UserViewModel>()
                            .ForMember(d => d.Name, d => d.MapFrom(s => s.FirstName))
                            .ReverseMap();
            CreateMap<Post, PostViewModel>()
                            .ReverseMap();
            CreateMap<User, ProjViewModel>()
                            .ReverseMap();
        }
    }
}
