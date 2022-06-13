using SiteManagement.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Dto
{
    public class DtoUserToken : DtoBase
    {
        public object AccessToken { get; set; }
        public DtoUserLogin DtoUserLogin { get; set; }
    }
}
