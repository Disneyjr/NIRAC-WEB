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
        public T GetEntityFindString(string FieldString, string Research)
        {
            string url = Url + Research + "/" + FieldString;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var response = wc.DownloadString(url);
            T t = JsonConvert.DeserializeObject<T>(response);
            return t;
        }
        public T GetEntityFindInt(int FieldInt, string Research)
        {
            string url = Url + Research + "/" + FieldInt;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var response = wc.DownloadString(url);
            T t = JsonConvert.DeserializeObject<T>(response);
            return t;
        }
        public List<T> GetListFindInt(int FieldInt, string Research)
        {
            string url = Url + Research + FieldInt;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var response = wc.DownloadString(url);
            List<T> t = JsonConvert.DeserializeObject<List<T>>(response);
            return t;
        }
        public List<T> GetListFindString(string FieldString, string Research)
        {
            string url = Url + Research + FieldString;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var response = wc.DownloadString(url);
            return JsonConvert.DeserializeObject<List<T>>(response);
        }
        #region CRUD
        public T Get(int FieldInt, string Research)
        {
            string url = Url + Research + "/" + FieldInt;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var response = wc.DownloadString(url);
            T t = JsonConvert.DeserializeObject<T>(response);
            return t;
        }
        public List<T> GetAll(string Research)
        {
            string url = Url + Research;
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var response = wc.DownloadString(url);
            List<T> t = JsonConvert.DeserializeObject<List<T>>(response);
            return t;
        }
        public T Add(T Obj, string Research)
        {
            string url = Url + Research;
            var upload = JsonConvert.SerializeObject(Obj);
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var result = wc.UploadString(url, upload);
            var mater = JsonConvert.DeserializeObject<T>(result);
            return mater;
        }
        public T Update(T Obj, int FieldInt, string Research)
        {
            string url = Url + Research + "/" + FieldInt;
            var upload = JsonConvert.SerializeObject(Obj);
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var result = wc.UploadString(url, "PUT", upload);
            var mater = JsonConvert.DeserializeObject<T>(result);
            return mater;
        }
        public T Delete(T Obj, int FieldInt, string Research)
        {
            string url = Url + Research + "/" + FieldInt;
            var upload = JsonConvert.SerializeObject(Obj);
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
            wc.Encoding = Encoding.UTF8;
            var result = wc.UploadString(url, "DELETE", upload);
            var mater = JsonConvert.DeserializeObject<T>(result);
            return mater;
        }
        #endregion

    }
}