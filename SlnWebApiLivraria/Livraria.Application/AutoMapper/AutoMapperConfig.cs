using AutoMapper;

namespace Livraria.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                #region DOMAIN TO VIEWMODELb

                #region CONFIGURAÇÃO SIMPLES

                x.AddProfile<MappingProfile>();

                #endregion

                #endregion

                #region VIEWMODEL TO DOMAIN

                #endregion
            });
        }
    }
}
