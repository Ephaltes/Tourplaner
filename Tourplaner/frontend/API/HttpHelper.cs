using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestWebservice_RemoteCompiling.Helpers
{
    public class HttpHelper : IDisposable , IHttpHelper
    {
        private string _host;
        private static readonly HttpClient _client = new HttpClient();

        public HttpHelper(string host)
        {
            _host = host;
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.Timeout = TimeSpan.FromMinutes(5); //Debug Code
            
        }
        
        public async Task<HttpResponseMessage> ExecuteGet(string url)
        {
            return _client.GetAsync(_host + url).Result;
        }
        public async Task<HttpResponseMessage> ExecutePost(string url, string data)
        {
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            return await _client.PostAsync(_host + url, content);
        }
        public async Task<HttpResponseMessage> ExecutePost(string url, object dataObj)
        {
            return await ExecutePost(url, JsonConvert.SerializeObject(dataObj));
        }
        
        public async Task<HttpResponseMessage> ExecutePut(string url, string data)
        {
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            return await _client.PutAsync(_host + url, content);
        }

        public async Task<HttpResponseMessage> ExecutePut(string url, object dataObj)
        {
            return await ExecutePut(url, JsonConvert.SerializeObject(dataObj));
        }

        public async Task<HttpResponseMessage> ExecuteDelete(string url)
        {
            return await _client.DeleteAsync(_host + url);
        }
        
        public void Dispose()
        {
            _host = null;
        }
    }
}