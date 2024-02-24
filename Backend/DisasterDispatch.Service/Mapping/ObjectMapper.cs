using AutoMapper;
using DisasterDispatch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterDispatch.Service.Mapping
{
    public class ObjectMapper
    {
        private readonly static Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
                cfg.AddProfile<TitleMapper>();
                cfg.AddProfile<TitleTypeMapper>();
                cfg.AddProfile<SkillCategoryMapper>();
                cfg.AddProfile<SkillMapper>();
                cfg.AddProfile<PhoneNumberMapper>();
                cfg.AddProfile<DisasterCategoryMapper>();
                cfg.AddProfile<DisasterOperationMapper>();
                cfg.AddProfile<EmergencyReportMapper>();
                cfg.AddProfile<AddressMapper>();
                cfg.AddProfile<CertificateMapper>();
                cfg.AddProfile<CustomOperationMapper>();
                cfg.AddProfile<OperationEmployeeMapper>();
                cfg.AddProfile<RoleMapper>();
                
                
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value;
    }
}
