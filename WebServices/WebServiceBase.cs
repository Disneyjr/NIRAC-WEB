using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using NIRAC_BUSINESS.DAO;
using NIRAC_BUSINESS.Models.API_CONFIG;

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
            this.Url = url + "api/Usuario";
        }
        
        public T GetUserPassword(string User)
        {
            this.wc.Encoding = Encoding.UTF8;
            string url = this.Url + "/ValidUserPassword/" + User;
            try
            {
                var response = wc.DownloadString(url);
                T t = JsonConvert.DeserializeObject<T>(response);
                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T GetUserbyEmail(string email)
        {
            this.wc.Encoding = Encoding.UTF8;
            try
            {
                string url = this.Url + "/" + email;
                var response = this.wc.DownloadString(url);
                T t = JsonConvert.DeserializeObject<T>(response);
                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T Add(T t)
        {
            try
            {
                var upload = JsonConvert.SerializeObject(t);
                this.wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                this.wc.Encoding = Encoding.UTF8;
                var result = this.wc.UploadString(this.Url, upload);
                var mater = JsonConvert.DeserializeObject<T>(result);
                return mater;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T Update(T t, int id)
        {
            try
            {
                string urlPut = this.Url + "/" + id;
                var upload = JsonConvert.SerializeObject(t);
                this.wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                this.wc.Encoding = Encoding.UTF8;
                var result = this.wc.UploadString(urlPut, "PUT", upload);
                var mater = JsonConvert.DeserializeObject<T>(result);
                return mater;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T Delete(T t, int id)
        {
            try
            {
                string urlDelete = this.Url + "/" + id;
                var upload = JsonConvert.SerializeObject(t);
                this.wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                this.wc.Encoding = Encoding.UTF8;
                var result = this.wc.UploadString(urlDelete, "DELETE", upload);
                var mater = JsonConvert.DeserializeObject<T>(result);
                return mater;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}