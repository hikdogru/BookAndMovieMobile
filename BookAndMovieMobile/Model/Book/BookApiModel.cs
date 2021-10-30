using BookAndMovieMobile.Model.Json;
using BookAndMovieMobile.Model.RestApi;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Book
{
    public class BookApiModel
    {
        public List<BookInfoModel> GetBookFromGoogle(string url)
        {
            string clientUrl = url;
            var restApiModel = new RestApiModel(url: clientUrl, method: Method.GET);
            IRestResponse response = restApiModel.GetRestResponse();
            var jsonConvertModel = new JsonConvertModel(new CamelCaseNamingStrategy());
            var bookJsonModel = jsonConvertModel.GetContent<BookJsonModel>(response.Content);
            return bookJsonModel.Items;
        }

        public List<BookInfoModel> GetBookFromGoogle(string url, Method method)
        {
            string clientUrl = url;
            var request = new RestRequest(method);
            request.AddHeader("authorization", "Bearer ya29.a0ARrdaM_YJbDBBYkqoRKSO0-ySSRs2j-lh_rGbL2bazuqrj6YFENVJqZ9P9ofET8i0Bjarbt-B5XnoexyTgie1tA0dIqFTCNUvyC4sDh5vVNbMf622ZxSwPAkU2iiiR-9_xoeZxqoQsG4OUTKRGbTX0fdqezk");
            var client = new RestApiModel(url: clientUrl, request: request);
            IRestResponse response = client.GetRestResponse(request: client.Request);
            var jsonConvertModel = new JsonConvertModel(new CamelCaseNamingStrategy());
            var bookJsonModel = jsonConvertModel.GetContent<BookJsonModel>(response.Content);
            return bookJsonModel.Items;
        }

        public void AddBookToGoogle(string url, Method method)
        {
            var request = new RestRequest(method);
            request.AddHeader("content-type", "application/json;charset=utf-8");
            request.AddHeader("authorization", "Bearer ya29.a0ARrdaM_YJbDBBYkqoRKSO0-ySSRs2j-lh_rGbL2bazuqrj6YFENVJqZ9P9ofET8i0Bjarbt-B5XnoexyTgie1tA0dIqFTCNUvyC4sDh5vVNbMf622ZxSwPAkU2iiiR-9_xoeZxqoQsG4OUTKRGbTX0fdqezk");
            var client = new RestApiModel(url: url, request: request);
            IRestResponse response = client.GetRestResponse(request: client.Request);
        }
    }
}
