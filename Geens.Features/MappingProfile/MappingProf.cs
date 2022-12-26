using AutoMapper;
using Geens.Features.Dtos.Adresses;
using Geens.Features.Dtos.Enseignants;
using Geens.Domain.Modeles;
using Geens.Api.DTOs.Enseignants;
using MsCommun.Messages.Enseignants;

namespace Geens.Features.MappingProfile
{
    public class MappingProf: Profile
    {
        public MappingProf()
        {

            // Adresses
            CreateMap<Adresse, AdresseDto>().ReverseMap();
            CreateMap<Adresse, AdresseDetailDto>().ReverseMap();
            CreateMap<Adresse, AdresseACreerDto>().ReverseMap();
            CreateMap<Adresse, AdresseAModifierDto>().ReverseMap();

            // Enseignant
            CreateMap<Enseignant, EnseignantDto>().ReverseMap();
            CreateMap<Enseignant, EnseignantACreerDto>().ReverseMap();
            CreateMap<Enseignant, EnseignantDetailDto>().ReverseMap();
            CreateMap<Enseignant, EnseignantAModifierDto>().ReverseMap();
            CreateMap<Enseignant, MsCommun.Messages.Enseignants.EnseignantACreerMessage>()
                .ForMember(dest => dest.NumeroExterne,
                opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<Enseignant, EnseignantAModifierMessage>()
                .ForMember(dest => dest.NumeroExterne,
                opt => opt.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
