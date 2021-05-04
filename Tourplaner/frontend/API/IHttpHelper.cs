using System.Net.Http;
using System.Threading.Tasks;

namespace RestWebservice_RemoteCompiling.Helpers
{
    public interface IHttpHelper
    {
        public  Task<HttpResponseMessage> ExecuteGet(string url);
        public  Task<HttpResponseMessage> ExecutePost(string url, string data);
        public  Task<HttpResponseMessage> ExecutePost(string url, object dataObj);
        public  Task<HttpResponseMessage> ExecuteDelete(string url);
        public Task<HttpResponseMessage> ExecutePut(string url, string data);
        public Task<HttpResponseMessage> ExecutePut(string url, object dataObj);



    }
}