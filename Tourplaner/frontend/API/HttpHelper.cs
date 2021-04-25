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
        }
        
        public async Task<HttpResponseMessage> ExecuteGet(string url)
        {
            return  await _client.GetAsync(_host + url);
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
        
        public void Dispose()
        {
            _host = null;
        }
    }
}