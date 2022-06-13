using SiteManagement.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Base
{
    //response var Iresponse'tan kalitim alir
    public class Response : IResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }
    public class Response<T> : IResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        //Data'da generic olacak, personelistesi ya da sadece sayi gibi degerlerin hepsini kapsayabilir,
        public T Data { get; set; }
    }
}
