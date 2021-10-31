using BookAndMovieMobile.Model.Google;
using BookAndMovieMobile.Model.Json;
using BookAndMovieMobile.Model.RestApi;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BookAndMovieMobile.Model.Book
{
    public class BookApiModel
    {
        public string AccessToken { get; set; }
        public BookApiModel()
        {

            CreateAccessToken();
        }

        private void CreateAccessToken()
        {
            string clientUrl = "https://accounts.google.com/o/oauth2/token?client_id=668421021254-it30nabhrt3fpp33pgul1t5jhavhau54.apps.googleusercontent.com&client_secret=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&refresh_token=1//04UNUaTaoelghCgYIARAAGAQSNwF-L9IrB-sk79dqnmuTzX2yJVxsJaKTLuzl3IqljpXjlTjmNZv8OmOvKXmLC3AbmfOSiiqm8JU&grant_type=refresh_token";
            var request = new RestRequest(Method.POST);
            var client = new RestApiModel(url: clientUrl, request: request);
            IRestResponse response = client.GetRestResponse(request: client.Request);
            var jsonConvertModel = new JsonConvertModel(new SnakeCaseNamingStrategy());
            var tokenModel = jsonConvertModel.GetContent<GoogleTokenModel>(response.Content);
            AccessToken = tokenModel.AccessToken;
        }

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
            request.AddHeader("authorization", $"Bearer {AccessToken}");
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
            request.AddHeader("authorization", $"Bearer {AccessToken}");
            var client = new RestApiModel(url: url, request: request);
            IRestResponse response = client.GetRestResponse(request: client.Request);
        }
    }
}
