using AutoMapper;
using SiteManagement.Entity.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Bll
{
    internal class ObjectMapper
    {
        static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            //profilemizi gec olusturmasini istiyoruz
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return config.CreateMapper();
        }
        );

        public static IMapper Mapper => lazy.Value;
    }
}
