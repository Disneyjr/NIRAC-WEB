using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace NIRAC_WEB.WebServices
{
    public class WebServiceBase<T>
        where T : class
    {
        private WebClient wc;
        private string Url;
        public WebServiceBase(string url,string obj)
        {
            this.wc = new WebClient();
            this.Url = url;
        }
        
        public T GetUserPassword(string User, string Password)
        {
            this.wc.Encoding = Encoding.UTF8;
            string url = this.Url +"/"+ User +"/"+ Password;
            try
            {
                var response = wc.DownloadString(url);
                T t = JsonConvert.DeserializeObject<T>(response);
                return t;
            }
            catch
            {
                return null;
            }
        }

    }
}