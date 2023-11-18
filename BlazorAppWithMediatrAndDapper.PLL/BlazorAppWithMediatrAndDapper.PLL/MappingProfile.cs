using AutoMapper;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.DAL.Entities;

namespace BlazorAppWithMediatrAndDapper.PLL;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		ShouldMapField = fieldInfo => true;
		ShouldMapProperty = propertyInfo => true;
		CreateMap<ProviderEntity, Provider>();
		CreateMap<Provider, ProviderEntity>();
	}
}
