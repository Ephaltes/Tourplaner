using System.Net.Http;
using System.Threading.Tasks;

namespace RestWebservice_RemoteCompiling.Helpers
{
    public interface IHttpHelper
    {
        public  Task<string> ExecuteGet(string url);
        public  Task<HttpResponseMessage> ExecutePost(string url, string data);
        public  Task<HttpResponseMessage> ExecutePost(string url, object dataObj);
    }
}