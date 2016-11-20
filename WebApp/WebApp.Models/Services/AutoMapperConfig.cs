using AutoMapper;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Services
{
    /// <summary>
    /// Must be called from the web or dependent project
    /// </summary>
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
      {
          cfg.CreateMap<Address, AddressViewModel>().ReverseMap();

      });

        }

    }
}
