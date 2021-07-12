using System;
using System.Collections.Generic;
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
        public WebServiceBase(string url)
        {
            this.wc = new WebClient();
            this.Url = url + "api/";
        }
        public T GetEntitybyString(string entity, string Pesquisa)
        {
            wc.Encoding = Encoding.UTF8;
            string url = Url + Pesquisa + "/" + entity;
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
        public List<T> GetListId(int entity, string Pesquisa)
        {
            wc.Encoding = Encoding.UTF8;
            string url = Url + Pesquisa + entity;
            try
            {
                var response = wc.DownloadString(url);
                List<T> t = JsonConvert.DeserializeObject<List<T>>(response);
                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T GetEntitybyInt(int id, string Pesquisa)
        {
            wc.Encoding = Encoding.UTF8;
            string url = Url + Pesquisa + "/" + id;
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
        #region CRUD
        public T Get(int id, string obj)
        {
            wc.Encoding = Encoding.UTF8;
            string url = Url + obj + "/" + id;
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
        public List<T> GetAll(string obj)
        {
            wc.Encoding = Encoding.UTF8;
            string url = Url + obj;
            try
            {
                var response = wc.DownloadString(url);
                List<T> t = JsonConvert.DeserializeObject<List<T>>(response);
                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T Add(T t, string obj)
        {
            string url = Url + obj;
            try
            {
                var upload = JsonConvert.SerializeObject(t);
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Encoding = Encoding.UTF8;
                var result = wc.UploadString(url, upload);
                var mater = JsonConvert.DeserializeObject<T>(result);
                return mater;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T Update(T t, int id, string obj)
        {
            string url = Url + obj + "/" + id;
            try
            {
                var upload = JsonConvert.SerializeObject(t);
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Encoding = Encoding.UTF8;
                var result = wc.UploadString(url, "PUT", upload);
                var mater = JsonConvert.DeserializeObject<T>(result);
                return mater;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public T Delete(T t, int id, string obj)
        {
            string url = Url + obj + "/" + id;
            try
            {
                var upload = JsonConvert.SerializeObject(t);
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Encoding = Encoding.UTF8;
                var result = wc.UploadString(url, "DELETE", upload);
                var mater = JsonConvert.DeserializeObject<T>(result);
                return mater;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}