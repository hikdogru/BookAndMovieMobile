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
    }
}
