using AutoMapper;

namespace Demo.mvc.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMapings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}