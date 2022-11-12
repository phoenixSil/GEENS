using AutoMapper;
using Geens.Api.Dtos.Adresses;
using Geens.Api.Dtos.Enseignants;
using Geens.Api.DTOs.Adresses;
using Geens.Api.Modeles;
using Geens.Api.DTOs.Enseignants;

namespace Geens.Api.MappingProfile
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
            CreateMap<Enseignant, EnseignantGdcACreerDto>()
                .ForMember(dest => dest.NumeroExterne,
                opt => opt.MapFrom(src => src.Id));
        }
    }
}
