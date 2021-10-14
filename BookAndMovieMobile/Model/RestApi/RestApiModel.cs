using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovieMobile.Model.RestApi
{
    public class RestApiModel
    {
        private readonly string _url;
        private readonly Method _method;

        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }

        public RestApiModel(string url, Method method)
        {
            _url = url;
            _method = method;
            GetRestClient();
        }

        private void GetRestClient()
        {
            Client = new RestClient(_url);
            Client.Timeout = -1;
            GetRestRequest();
        }

        public void GetRestRequest()
        {
            Request = new RestRequest(_method);
        }

        public IRestResponse GetRestResponse()
        {
            return  Client.Execute(Request);
        }

        public IRestResponse GetRestResponse(RestRequest request = null)
        {
            return Client.Execute(request);
        }
    }
}
