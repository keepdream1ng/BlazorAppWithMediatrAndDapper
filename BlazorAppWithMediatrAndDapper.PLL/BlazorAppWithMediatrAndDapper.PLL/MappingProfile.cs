using AutoMapper;
using BlazorAppWithMediatrAndDapper.BLL.Models;
using BlazorAppWithMediatrAndDapper.DAL.Entities;
using BlazorAppWithMediatrAndDapper.PLL.Client.ViewModels;

namespace BlazorAppWithMediatrAndDapper.PLL;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		ShouldMapField = fieldInfo => true;
		ShouldMapProperty = propertyInfo => true;
		CreateMap<ProviderEntity, Provider>();
		CreateMap<OrderItemViewModel, OrderItem>();
		CreateMap<Order, OrderEntity>()
			.ForMember(oE => oE.ProviderId,
			opt => opt.MapFrom(o => o.Provider.Id))
			.ForMember(oE => oE.Date,
			opt => opt.MapFrom(o => o.Date.ToString("YYYY-MM-DD")));
		CreateMap<OrderItem, OrderItemEntity>();
	}
}
