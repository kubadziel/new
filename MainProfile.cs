using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModels.VM;

namespace Kolokwium.Services.Configuration.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<AddStoreVm, Store>();
            CreateMap<UpdateStoreVm, Store>();
            CreateMap<StoreVm, Store>();
            CreateMap<Store, StoreVm>();

        }
    }
}